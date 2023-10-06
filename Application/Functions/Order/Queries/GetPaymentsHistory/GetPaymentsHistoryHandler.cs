using Application.Contracts.Persistence;
using Application.Functions.Order.Queries.GetOrders;
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

namespace Application.Functions.Order.Queries.GetPaymentsHistory
{
    public class GetPaymentsHistoryHandler : IRequestHandler<GetPaymentsHistoryQuery, BaseResponse<List<GetPaymentsHistoryDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserService _userService;

        public GetPaymentsHistoryHandler(
            IMapper mapper,
            IPaymentRepository paymentRepository,
            IUserService userService)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
            _userService = userService;
        }

        public async Task<BaseResponse<List<GetPaymentsHistoryDto>?>> Handle(GetPaymentsHistoryQuery request, CancellationToken cancellationToken)
        {
            if (!_userService.IsAuthenticated())
                return new BaseResponse<List<GetPaymentsHistoryDto>?>(false, "No Authenticated");

            var userId = _userService.GetUserId() ?? Guid.Empty;
            var payments = await _paymentRepository.GetPaymentsByUserId(userId);

            if (payments == null || !payments.Any())
                return new BaseResponse<List<GetPaymentsHistoryDto>?>(false, "No payments");

            return new BaseResponse<List<GetPaymentsHistoryDto>?>(
                _mapper.Map<List<GetPaymentsHistoryDto>>(payments), true);
        }
    }
}
