using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, BaseResponse<List<GetOrdersDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(
            IMapper mapper,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<List<GetOrdersDto>?>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUserId(request.UserId);

            if (orders == null || !orders.Any())
                return new BaseResponse<List<GetOrdersDto>?>(false, "No orders");

            return new BaseResponse<List<GetOrdersDto>?>(
                _mapper.Map<List<GetOrdersDto>>(orders), true);
        }
    }
}
