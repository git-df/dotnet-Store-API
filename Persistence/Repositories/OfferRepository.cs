using Application.Contracts.Persistence;
using Application.Functions.Offer.Queries.GetOffers;
using DF.Query.Pagination;
using DF.Query.Pagination.Models.Requests;
using DF.Query.Pagination.Models.Responses;
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

        public async Task<PaginatedList<GetOffersDto>> GetAllActive(Pagination pagination,
            CancellationToken cancellationToken = default)
        {
            var query =
                from offers in _storeDbContext.Offers
                where offers.Active == true
                select new GetOffersDto()
                {
                    Id = offers.Id,
                    Name = offers.Name,
                    ImageUrl = offers.ImageUrl,
                    Price = offers.Price
                };

            return await query.GetPaginatedListAsync(pagination, cancellationToken);
        }
    }
}
