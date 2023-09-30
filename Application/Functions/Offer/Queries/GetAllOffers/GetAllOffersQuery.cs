using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Queries.GetAllOffers
{
    public class GetAllOffersQuery : IRequest<BaseResponse<List<GetAllOffersDto>?>>
    {
    }
}
