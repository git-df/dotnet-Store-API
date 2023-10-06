using Application.Functions.Order.Commands.AddOrder;
using Application.Functions.Order.Commands.ChangeOrderStatus;
using Application.Functions.Order.Commands.Pay;
using Application.Functions.Order.Queries;
using Application.Functions.Order.Queries.GetAllOrders;
using Application.Functions.Order.Queries.GetAllPayments;
using Application.Functions.Order.Queries.GetOrders;
using Application.Functions.Order.Queries.GetPaymentsHistory;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [Route("GetOrders")]
        public async Task<BaseResponse<List<GetOrdersDto>?>> GetOrders()
        {
            return await _mediator.Send(new GetOrdersQuery());
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin")]
        [Route("GetAllOrders")]
        public async Task<BaseResponse<List<GetAllOrdersDto>?>> GetAllOrders()
        {
            return await _mediator.Send(new GetAllOrdersQuery());
        }

        [HttpGet]
        [Authorize]
        [Route("GetOrderDetails")]
        public async Task<BaseResponse> GetOrderDetails()
        {
            return new BaseResponse(true);
        }

        [HttpPost]
        [Authorize]
        [Route("AddOrder")]
        public async Task<BaseResponse<int?>> AddOrder([FromBody] AddOrderCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        [Authorize(Roles = "Employee, Admin")]
        [Route("ChangeOrderStatus")]
        public async Task<BaseResponse> ChangeOrderStatus([FromBody] ChangeOrderStatusCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        [Authorize]
        [Route("GetPaymentsHistory")]
        public async Task<BaseResponse<List<GetPaymentsHistoryDto>?>> GetPaymentsHistory()
        {
            return await _mediator.Send(new GetPaymentsHistoryQuery());
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin")]
        [Route("GetAllPayments")]
        public async Task<BaseResponse<List<GetAllPaymentsDto>?>> GetAllPayments()
        {
            return await _mediator.Send(new GetAllPaymentsQuery());
        }

        [HttpPut]
        [Authorize]
        [Route("Pay")]
        public async Task<BaseResponse> Pay([FromBody]PayCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
