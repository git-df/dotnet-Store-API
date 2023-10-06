using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Commands.Pay
{
    public class PayCommand : IRequest<BaseResponse>
    {
        public Guid PaymentId { get; set; }
    }
}
