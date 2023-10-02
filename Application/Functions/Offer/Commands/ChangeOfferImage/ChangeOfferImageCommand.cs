using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.ChangeOfferImage
{
    public class ChangeOfferImageCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
