using Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        [HttpGet]
        [Route("GetOffers")]
        public async Task<BaseResponse> GetOffers()
        {
            return new BaseResponse(true);
        }

        [HttpGet]
        [Route("GetAllOffers")]
        public async Task<BaseResponse> GetAllOffers()
        {
            return new BaseResponse(true);
        }

        [HttpGet]
        [Route("GetOfferDetails")]
        public async Task<BaseResponse> GetOfferDetails()
        {
            return new BaseResponse(true);
        }

        [HttpPost]
        [Route("AddOffer")]
        public async Task<BaseResponse> AddOffer()
        {
            return new BaseResponse(true);
        }

        [HttpPost]
        [Route("UpdateOffer")]
        public async Task<BaseResponse> UpdateOffer()
        {
            return new BaseResponse(true);
        }

        [HttpPut]
        [Route("ChangeOfferActive")]
        public async Task<BaseResponse> ChangeOfferActive()
        {
            return new BaseResponse(true);
        }

        [HttpPut]
        [Route("ChangeOfferImage")]
        public async Task<BaseResponse> ChangeOfferImage()
        {
            return new BaseResponse(true);
        }

        [HttpDelete]
        [Route("DeleteOffer")]
        public async Task<BaseResponse> DeleteOffer()
        {
            return new BaseResponse(true);
        }
    }
}
