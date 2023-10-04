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
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";

            return await _mediator.Send(new GetOrdersQuery() { UserId = new Guid(stringClaimId) });
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
        public async Task<BaseResponse> AddOffer()
        {
            return new BaseResponse(true);
        }

        [HttpPut]
        [Authorize(Roles = "Employee, Admin")]
        [Route("ChangeOrderStatus")]
        public async Task<BaseResponse> ChangeOrderStatus()
        {
            return new BaseResponse(true);
        }

        [HttpGet]
        [Authorize]
        [Route("GetPaymentsHistory")]
        public async Task<BaseResponse<List<GetPaymentsHistoryDto>?>> GetPaymentsHistory()
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";

            return await _mediator.Send(new GetPaymentsHistoryQuery() { UserId = new Guid(stringClaimId) });
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
        [Route("Pay/{paymentId}")]
        public async Task<BaseResponse> Pay(Guid paymentId)
        {
            string stringClaimId = (HttpContext.User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "0";

            return await _mediator.Send(new PayCommand() { UserId = new Guid(stringClaimId), PaymentId = paymentId });
        }
    }
}
