﻿using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NodaTime;
using Sig.App.Backend.DbModel;
using Sig.App.Backend.DbModel.Entities.Transactions;
using Sig.App.Backend.DbModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sig.App.Backend.DbModel.Entities.Beneficiaries;
using Sig.App.Backend.DbModel.Entities.Subscriptions;
using Sig.App.Backend.DbModel.Entities.TransactionLogs;
using Sig.App.Backend.Helpers;

namespace Sig.App.Backend.BackgroundJobs
{
    public class ExpireFundsFromCard
    {
        private readonly AppDbContext db;
        private readonly IClock clock;
        private readonly ILogger<ExpireFundsFromCard> logger;

        public ExpireFundsFromCard(AppDbContext db, IClock clock, ILogger<ExpireFundsFromCard> logger)
        {
            this.db = db;
            this.clock = clock;
            this.logger = logger;
        }

        public static void RegisterJob(IConfiguration config)
        {
            var cronFirstDayOfMonth = Cron.Monthly();
            RecurringJob.AddOrUpdate<ExpireFundsFromCard>("ExpireFundsFromCard",
                x => x.Run(),
                Cron.Daily(),
                TimeZoneInfo.FindSystemTimeZoneById(config["systemLocalTimezone"]));
        }

        public async Task Run()
        {
            var today = clock.GetCurrentInstant().InUtc().ToDateTimeUtc();

            var dbTransactions = await db.Transactions.OfType<AddingFundTransaction>()
                .Include(x => x.ProductGroup)
                .Include(x => x.Card).ThenInclude(x => x.Funds)
                .Include(x => x.Beneficiary).ThenInclude(x => x.Organization)
                .Where(x => x.Status == FundTransactionStatus.Actived && x.ExpirationDate <= today).ToListAsync();

            var transactions = dbTransactions.Where(x =>
                x is ManuallyAddingFundTransaction or SubscriptionAddingFundTransaction
                    or OffPlatformAddingFundTransaction).ToList();
            var maftSubscriptions = await db.Subscriptions
                .Where(x => transactions.OfType<ManuallyAddingFundTransaction>().Select(y => y.SubscriptionId).Contains(x.Id))
                .ToListAsync();
            var saftSubscriptionTypes = await db.SubscriptionTypes
                .Include(x => x.Subscription)
                .Where(x => transactions.OfType<SubscriptionAddingFundTransaction>().Select(x => x.SubscriptionTypeId)
                    .Contains(x.Id)).ToListAsync();
            foreach (var transaction in transactions)
            {
                var transactionProductGroupId = (transaction as IHaveProductGroup).ProductGroupId;
                var fund = transaction.Card.Funds.FirstOrDefault(x => x.ProductGroupId == transactionProductGroupId);
                if (fund != null)
                {
                    Subscription subscription = null;
                    if (transaction is ManuallyAddingFundTransaction maft)
                        subscription = maftSubscriptions.FirstOrDefault(x => x.Id == maft.SubscriptionId);
                    if (transaction is SubscriptionAddingFundTransaction saft)
                        subscription = saftSubscriptionTypes.FirstOrDefault(x => x.Id == saft.SubscriptionTypeId)?.Subscription;
                    fund.Amount -= transaction.AvailableFund;
                    
                    var transactionUniqueId = TransactionHelper.CreateTransactionUniqueId();
                    
                    var transactionLogProductGroups = new List<TransactionLogProductGroup>()
                    {
                        new()
                        {
                            Amount = transaction.AvailableFund,
                            ProductGroupId = transaction.ProductGroupId,
                            ProductGroupName = transaction.ProductGroup.Name
                        }
                    };
                    
                    db.TransactionLogs.Add(new TransactionLog()
                    {
                        Discriminator = TransactionLogDiscriminator.ExpireFundTransactionLog,
                        TransactionUniqueId = transactionUniqueId,
                        CreatedAtUtc = today,
                        TotalAmount = transaction.AvailableFund,
                        CardProgramCardId = transaction.Card.ProgramCardId,
                        CardNumber = transaction.Card.CardNumber,
                        BeneficiaryId = transaction.BeneficiaryId,
                        BeneficiaryID1 = transaction.Beneficiary.ID1,
                        BeneficiaryID2 = transaction.Beneficiary.ID2,
                        BeneficiaryFirstname = transaction.Beneficiary.Firstname,
                        BeneficiaryLastname = transaction.Beneficiary.Lastname,
                        BeneficiaryEmail = transaction.Beneficiary.Email,
                        BeneficiaryPhone = transaction.Beneficiary.Phone,
                        BeneficiaryIsOffPlatform = transaction.Beneficiary is OffPlatformBeneficiary,
                        BeneficiaryTypeId = transaction.Beneficiary.BeneficiaryTypeId,
                        OrganizationId = transaction.Beneficiary.OrganizationId,
                        OrganizationName = transaction.Beneficiary.Organization.Name,
                        SubscriptionId = subscription?.Id,
                        SubscriptionName = subscription?.Name,
                        ProjectId = transaction.Beneficiary.Organization.ProjectId,
                        TransactionLogProductGroups = transactionLogProductGroups
                    });
                    
                    transaction.Card.Transactions.Add(new ExpireFundTransaction()
                    {
                        TransactionUniqueId = transactionUniqueId,
                        Amount = transaction.AvailableFund,
                        Card = transaction.Card,
                        CreatedAtUtc = today,
                        ProductGroupId = transactionProductGroupId
                    });
                    transaction.AvailableFund = 0;
                    transaction.Status = FundTransactionStatus.Expired;
                }
            }

            await db.SaveChangesAsync();
        }
    }
}
