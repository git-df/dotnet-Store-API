using Application.Contracts.Persistence;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Hangfire;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Application.Services.Interfaces;

namespace Application.Functions.Order.Commands.Pay
{
    public class PayHandler : IRequestHandler<PayCommand, BaseResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IUserService _userService;

        public PayHandler(
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository,
            IBackgroundJobClient backgroundJobClient,
            IUserService userService)
        {
            _orderRepository = orderRepository;
            _backgroundJobClient = backgroundJobClient;
            _paymentRepository = paymentRepository;
            _userService = userService;
        }

        public async Task<BaseResponse> Handle(PayCommand request, CancellationToken cancellationToken)
        {
            if (!_userService.IsAuthenticated())
                return new BaseResponse(false, "No Authenticated");

            var userId = _userService.GetUserId();

            var payment = await _paymentRepository.GetById(request.PaymentId);
            var order = await _orderRepository.GetById(payment?.OrderId ?? 0);

            if (payment == null || order == null)
                return new BaseResponse(false, "Bad payment id");

            if (order.AppUserId != userId || payment.AppUserId != userId)
                return new BaseResponse(false, "This payment is not for you");

            if (payment.Status != PaymentStatus.New || order.Status != OrderStatus.New)
                return new BaseResponse(false, "Bad payment or order status");

            payment.Status = PaymentStatus.Completed;

            var updatedPayment = await _paymentRepository.Update(payment);

            if (updatedPayment == null)
                return new BaseResponse(false, "Something went wrong :(");

            _backgroundJobClient.Schedule(
                () => SetOrderInProgres(order.Id),
                TimeSpan.FromMinutes(5));

            return new BaseResponse(true, "Paid");
        }

        public async Task SetOrderInProgres(int orderId)
        {
            var order = await _orderRepository.GetById(orderId);

            if (order != null)
            {
                order.Status = OrderStatus.InProgres;

                await _orderRepository.Update(order);
            }
        }
    }
}
