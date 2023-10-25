﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sig.App.Backend.DbModel;

#nullable disable

namespace Sig.App.Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221017210705_ParticipantSortOrderUniqueId")]
    partial class ParticipantSortOrderUniqueId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AddingFundTransactionPaymentTransaction", b =>
                {
                    b.Property<long>("TransactionsId")
                        .HasColumnType("bigint");

                    b.Property<long>("TransactionsId1")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionsId", "TransactionsId1");

                    b.HasIndex("TransactionsId1");

                    b.ToTable("AddingFundTransactionPaymentTransaction");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FriendlyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Xml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastAccessTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Beneficiaries.Beneficiary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("BeneficiaryTypeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CardId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SortOrder")
                        .HasColumnType("bigint");

                    b.Property<string>("UniqueId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiaryTypeId");

                    b.HasIndex("CardId")
                        .IsUnique()
                        .HasFilter("[CardId] IS NOT NULL");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Beneficiaries.BeneficiaryType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Keys")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("BeneficiaryTypes");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Cards.Card", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal>("Fund")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Markets.Market", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Markets");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Organizations.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Profiles.UserProfile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Projects.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Projects.ProjectMarket", b =>
                {
                    b.Property<long>("MarketId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.HasKey("MarketId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectMarkets");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Subscriptions.Subscription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FundsExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MonthlyPaymentMoment")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Subscriptions.SubscriptionBeneficiary", b =>
                {
                    b.Property<long>("BeneficiaryId")
                        .HasColumnType("bigint");

                    b.Property<long>("SubscriptionId")
                        .HasColumnType("bigint");

                    b.HasKey("BeneficiaryId", "SubscriptionId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionBeneficiaries");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Subscriptions.SubscriptionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("BeneficiaryTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SubscriptionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiaryTypeId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionTypes");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Transactions.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("CardId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAtUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("Transactions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Transaction");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Transactions.AddingFundTransaction", b =>
                {
                    b.HasBaseType("Sig.App.Backend.DbModel.Entities.Transactions.Transaction");

                    b.Property<decimal>("AvailableFund")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("SubscriptionTypeId")
                        .HasColumnType("bigint");

                    b.HasIndex("SubscriptionTypeId");

                    b.HasDiscriminator().HasValue("AddingFundTransaction");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Transactions.PaymentTransaction", b =>
                {
                    b.HasBaseType("Sig.App.Backend.DbModel.Entities.Transactions.Transaction");

                    b.Property<long>("MarketId")
                        .HasColumnType("bigint");

                    b.HasIndex("MarketId");

                    b.HasDiscriminator().HasValue("PaymentTransaction");
                });

            modelBuilder.Entity("AddingFundTransactionPaymentTransaction", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Transactions.AddingFundTransaction", null)
                        .WithMany()
                        .HasForeignKey("TransactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sig.App.Backend.DbModel.Entities.Transactions.PaymentTransaction", null)
                        .WithMany()
                        .HasForeignKey("TransactionsId1")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sig.App.Backend.DbModel.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Beneficiaries.Beneficiary", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Beneficiaries.BeneficiaryType", "BeneficiaryType")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("BeneficiaryTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Sig.App.Backend.DbModel.Entities.Cards.Card", "Card")
                        .WithOne("Beneficiary")
                        .HasForeignKey("Sig.App.Backend.DbModel.Entities.Beneficiaries.Beneficiary", "CardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Sig.App.Backend.DbModel.Entities.Organizations.Organization", "Organization")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeneficiaryType");

                    b.Navigation("Card");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Beneficiaries.BeneficiaryType", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Projects.Project", "Project")
                        .WithMany("BeneficiaryTypes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Cards.Card", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Projects.Project", "Project")
                        .WithMany("Cards")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Organizations.Organization", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Projects.Project", "Project")
                        .WithMany("Organizations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Profiles.UserProfile", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.AppUser", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Sig.App.Backend.DbModel.Entities.Profiles.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Projects.ProjectMarket", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Markets.Market", "Market")
                        .WithMany("Projects")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sig.App.Backend.DbModel.Entities.Projects.Project", "Project")
                        .WithMany("Markets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Subscriptions.Subscription", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Projects.Project", "Project")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Subscriptions.SubscriptionBeneficiary", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Beneficiaries.Beneficiary", "Beneficiary")
                        .WithMany("Subscriptions")
                        .HasForeignKey("BeneficiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sig.App.Backend.DbModel.Entities.Subscriptions.Subscription", "Subscription")
                        .WithMany("Beneficiaries")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beneficiary");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Subscriptions.SubscriptionType", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Beneficiaries.BeneficiaryType", "BeneficiaryType")
                        .WithMany()
                        .HasForeignKey("BeneficiaryTypeId");

                    b.HasOne("Sig.App.Backend.DbModel.Entities.Subscriptions.Subscription", "Subscription")
                        .WithMany("Types")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeneficiaryType");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Transactions.Transaction", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Cards.Card", "Card")
                        .WithMany("Transactions")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Card");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Transactions.AddingFundTransaction", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Subscriptions.SubscriptionType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Transactions.PaymentTransaction", b =>
                {
                    b.HasOne("Sig.App.Backend.DbModel.Entities.Markets.Market", "Market")
                        .WithMany()
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.AppUser", b =>
                {
                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Beneficiaries.Beneficiary", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Beneficiaries.BeneficiaryType", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Cards.Card", b =>
                {
                    b.Navigation("Beneficiary");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Markets.Market", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Organizations.Organization", b =>
                {
                    b.Navigation("Beneficiaries");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Projects.Project", b =>
                {
                    b.Navigation("BeneficiaryTypes");

                    b.Navigation("Cards");

                    b.Navigation("Markets");

                    b.Navigation("Organizations");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Sig.App.Backend.DbModel.Entities.Subscriptions.Subscription", b =>
                {
                    b.Navigation("Beneficiaries");

                    b.Navigation("Types");
                });
#pragma warning restore 612, 618
        }
    }
}
