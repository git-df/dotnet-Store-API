using Application.Functions.Offer.Queries.GetOffers;
using DF.Query.Pagination.Models.Requests;
using DF.Query.Pagination.Models.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface IOfferRepository : IBaseRepository<Offer>
    {
        Task<PaginatedList<GetOffersDto>> GetAllActive(Pagination pagination,
            CancellationToken cancellationToken);
    }
}
