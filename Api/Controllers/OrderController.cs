using Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        [Route("GetOrders")]
        public async Task<BaseResponse> GetOrders()
        {
            return new BaseResponse(true);
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<BaseResponse> GetAllOrders()
        {
            return new BaseResponse(true);
        }

        [HttpGet]
        [Route("GetOrderDetails")]
        public async Task<BaseResponse> GetOrderDetails()
        {
            return new BaseResponse(true);
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<BaseResponse> AddOffer()
        {
            return new BaseResponse(true);
        }

        [HttpPut]
        [Route("ChangeOrderStatus")]
        public async Task<BaseResponse> ChangeOrderStatus()
        {
            return new BaseResponse(true);
        }

        [HttpGet]
        [Route("GetPayments")]
        public async Task<BaseResponse> GetPayments()
        {
            return new BaseResponse(true);
        }

        [HttpGet]
        [Route("GetAllPayments")]
        public async Task<BaseResponse> GetAllPayments()
        {
            return new BaseResponse(true);
        }

        [HttpPut]
        [Route("Pay")]
        public async Task<BaseResponse> Pay()
        {
            return new BaseResponse(true);
        }
    }
}
