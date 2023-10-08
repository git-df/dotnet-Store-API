using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<BaseResponse<GetOrderDetailsDto?>>
    {
        public int OrderId { get; set; }
    }
}
