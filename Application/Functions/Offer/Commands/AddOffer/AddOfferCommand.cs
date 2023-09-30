using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.AddOffer
{
    public class AddOfferCommand : IRequest<BaseResponse<int?>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
