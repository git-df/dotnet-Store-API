using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.DeleteOffer
{
    public class DeleteOfferCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
