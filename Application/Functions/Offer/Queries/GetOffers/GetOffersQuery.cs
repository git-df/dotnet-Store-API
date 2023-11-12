using Application.Responses;
using DF.Query.Pagination.Models.Requests;
using DF.Query.Pagination.Models.Responses;
using DF.Query.Sorting.Models.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Queries.GetOffers
{
    public class GetOffersQuery : IRequest<BaseResponse<PaginatedList<GetOffersDto>?>>
    {
        public Pagination Pagination { get; set; }
        public Sorting? Sorting { get; set; }
    }
}
