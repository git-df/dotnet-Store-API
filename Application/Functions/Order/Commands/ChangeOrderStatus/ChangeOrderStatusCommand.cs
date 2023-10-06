using Application.Responses;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Commands.ChangeOrderStatus
{
    public class ChangeOrderStatusCommand : IRequest<BaseResponse>
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
