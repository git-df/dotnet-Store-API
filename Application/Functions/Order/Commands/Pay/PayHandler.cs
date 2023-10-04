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

namespace Application.Functions.Order.Commands.Pay
{
    public class PayHandler : IRequestHandler<PayCommand, BaseResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public PayHandler(
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse> Handle(PayCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetById(request.PaymentId);
            var order = await _orderRepository.GetById(payment?.OrderId ?? 0);

            if (payment == null || order == null)
                return new BaseResponse(false, "Bad payment id");

            if (order.AppUserId != request.UserId || payment.AppUserId != request.UserId)
                return new BaseResponse(false, "This payment is not for you");

            if (payment.Status != PaymentStatus.New || order.Status != OrderStatus.New)
                return new BaseResponse(false, "Bad payment or order status");

            payment.Status = PaymentStatus.Completed;

            var updatedPayment = await _paymentRepository.Update(payment);

            if (updatedPayment == null)
                return new BaseResponse(false, "Something went wrong :(");

            order.Status = OrderStatus.InProgres;

            var updatedOrder = await _orderRepository.Update(order);

            if (updatedOrder == null)
                return new BaseResponse(false, "Something went wrong :(");

            return new BaseResponse(true, "Paid");
        }
    }
}
