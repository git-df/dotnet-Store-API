using Application.Contracts.Persistence;
using Application.Functions.Order.Queries.GetOrders;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, BaseResponse<List<GetAllOrdersDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(
            IMapper mapper,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<List<GetAllOrdersDto>?>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAll();

            if (orders == null || !orders.Any())
                return new BaseResponse<List<GetAllOrdersDto>?>(false, "No orders");

            return new BaseResponse<List<GetAllOrdersDto>?>(
                _mapper.Map<List<GetAllOrdersDto>>(orders), true);
        }
    }
}
