using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.ChangeOfferActive
{
    public class ChangeOfferActiveCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }
}
