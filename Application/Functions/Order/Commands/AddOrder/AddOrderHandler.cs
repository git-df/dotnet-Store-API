using Application.Contracts.Persistence;
using Application.Functions.Auth.Commands.SignUp;
using Application.Responses;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Commands.AddOrder
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, BaseResponse<int?>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AddOrderHandler(
            IOrderRepository orderRepository,
            IOfferRepository offerRepository,
            IPaymentRepository paymentRepository,
            IMapper mapper,
            IUserService userService)
        {
            _orderRepository = orderRepository;
            _offerRepository = offerRepository;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<BaseResponse<int?>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            if (!_userService.IsAuthenticated())
                return new BaseResponse<int?>(false, "No Authenticated");

            var userId = _userService.GetUserId();

            var validator = new AddOrderValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse<int?>(false, null, validationResult);

            if (request.Items == null || !request.Items.Any())
                return new BaseResponse<int?>(false, "No items");

            var order = _mapper.Map<Domain.Entities.Order>(request);
            order.Status = Domain.Enums.OrderStatus.New;
            order.AppUserId = userId;
            decimal price = 0;
            Domain.Entities.Offer? offer;

            foreach (var item in request.Items)
            {
                offer = await _offerRepository.GetById(item.OfferId);

                if (offer == null || !offer.Active)
                    return new BaseResponse<int?>(false, "Bad Item, offer id = " + item.OfferId);

                order.OrderItems.Add(new OrderItem()
                {
                    Count = item.Count,
                    OfferUrl = "/offer/"+item.OfferId,
                    Price = offer.Price,
                    ProductName = offer.Name
                });

                price += item.Count * offer.Price;
            }

            order = await _orderRepository.Add(order);

            if (order == null)
                return new BaseResponse<int?>(false, "Something went wrong :(");

            var payment = await _paymentRepository.Add(new Payment()
            {
                AppUserId = userId,
                OrderId = order.Id,
                Price = price,
                Status = Domain.Enums.PaymentStatus.New
            });

            if (payment == null)
                return new BaseResponse<int?>(false, "Something went wrong :(");

            return new BaseResponse<int?>(order.Id, true, "Ordder created");
        }
    }
}
