using Application.Contracts.Persistence;
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
    public class ChangeOrderStatusHandler : IRequestHandler<ChangeOrderStatusCommand, BaseResponse>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public ChangeOrderStatusHandler(
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetById(request.OrderId);
            var payment = await _paymentRepository.GetPaymentByOrderId(request.OrderId);

            if (order == null || payment == null)
                return new BaseResponse(false, "Bad order id");

            switch (request.Status)
            {
                case OrderStatus.InProgres:

                    if (order.Status != OrderStatus.New)
                        return new BaseResponse(false, "Order is not new");

                    order.Status = OrderStatus.InProgres;

                    order = await _orderRepository.Update(order);

                    if (order == null)
                        break;

                    return new BaseResponse(true, "Order updated");

                case OrderStatus.Completed:

                    if(order.Status != OrderStatus.InProgres)
                        return new BaseResponse(false, "Order is not in progres");

                    order.Status = OrderStatus.Completed;

                    order = await _orderRepository.Update(order);

                    if (order == null)
                        break;

                    return new BaseResponse(true, "Order updated");

                case OrderStatus.Rejected:

                    if (order.Status == OrderStatus.Completed || order.Status == OrderStatus.Rejected)
                        return new BaseResponse(false, "Order is "+order.Status.ToString());

                    order.Status = OrderStatus.Rejected;
                    payment.Status = PaymentStatus.Rejected;

                    order = await _orderRepository.Update(order);
                    payment = await _paymentRepository.Update(payment);

                    if (order == null || payment == null)
                        break;

                    return new BaseResponse(true, "Order updated");

                case OrderStatus.New:
                default:
                    return new BaseResponse(false, "Bad status");
            }

            return new BaseResponse(false, "Something went wrong :(");
        }
    }
}
