using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }

        public async Task<List<Offer>> GetAllActive()
        {
            return await _storeDbContext.Offers
                .Where(x => x.Active == true)
                .ToListAsync();
        }
    }
}
