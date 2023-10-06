using Application.Contracts.Persistence;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, BaseResponse<List<GetOrdersDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserService _userService;

        public GetOrdersHandler(
            IMapper mapper,
            IOrderRepository orderRepository,
            IUserService userService)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userService = userService;
        }

        public async Task<BaseResponse<List<GetOrdersDto>?>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            if (!_userService.IsAuthenticated())
                return new BaseResponse<List<GetOrdersDto>?>(false, "No Authenticated");

            var userId = _userService.GetUserId() ?? Guid.Empty;

            var orders = await _orderRepository.GetOrdersByUserId(userId);

            if (orders == null || !orders.Any())
                return new BaseResponse<List<GetOrdersDto>?>(false, "No orders");

            return new BaseResponse<List<GetOrdersDto>?>(
                _mapper.Map<List<GetOrdersDto>>(orders), true);
        }
    }
}
