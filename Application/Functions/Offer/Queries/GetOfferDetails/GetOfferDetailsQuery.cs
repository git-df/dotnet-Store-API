using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Queries.GetOfferDetails
{
    public class GetOfferDetailsQuery : IRequest<BaseResponse<GetOfferDetailsDto?>>
    {
        public int Id { get; set; }
    }
}
