using Application.Contracts.Persistence;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsQuery, BaseResponse<GetOrderDetailsDto?>>
    {
        private readonly IUserService _userService;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsHandler(
            IUserService userService,
            IOrderRepository orderRepository, 
            IMapper mapper)
        {
            _userService = userService;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetOrderDetailsDto?>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdWithItems(request.OrderId);

            if (order == null)
                return new BaseResponse<GetOrderDetailsDto?>(false, "Order not found");

            if (order.AppUserId != _userService.GetUserId()
                && !_userService.IsInRole("Admin")
                && !_userService.IsInRole("Employee"))
                return new BaseResponse<GetOrderDetailsDto?>(false, "it's not your order");

            return new BaseResponse<GetOrderDetailsDto?>(
                _mapper.Map<GetOrderDetailsDto>(order), true);
        }
    }
}
