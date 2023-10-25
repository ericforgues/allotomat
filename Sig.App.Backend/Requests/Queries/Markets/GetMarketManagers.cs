﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sig.App.Backend.Constants;
using Sig.App.Backend.DbModel;
using Sig.App.Backend.DbModel.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Sig.App.Backend.Requests.Queries.Markets
{
    public class GetMarketManagers : IRequestHandler<GetMarketManagers.Query, IList<AppUser>>
    {
        private readonly AppDbContext db;
        private readonly UserManager<AppUser> userManager;

        public GetMarketManagers(AppDbContext db, UserManager<AppUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IList<AppUser>> Handle(Query request, CancellationToken cancellationToken)
        {
            var claim = new Claim(AppClaimTypes.MarketManagerOf, request.MarketId.ToString());
            var managers = await userManager.GetUsersForClaimAsync(claim);

            if (request.IncludeProfiles)
            {
                var recruiterIds = managers.Select(r => r.Id);
                await db.UserProfiles.Where(x => recruiterIds.Contains(x.UserId)).LoadAsync(cancellationToken);
            }

            return managers;
        }

        public class Query : IRequest<IList<AppUser>>
        {
            public long MarketId { get; set; }
            public bool IncludeProfiles { get; set; }
        }
    }
}
