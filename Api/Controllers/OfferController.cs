using Application.Functions.Offer.Commands.AddOffer;
using Application.Functions.Offer.Queries.GetAllOffers;
using Application.Functions.Offer.Queries.GetOffers;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetOffers")]
        public async Task<BaseResponse<List<GetOffersDto>?>> GetOffers()
        {
            return await _mediator.Send(new GetOffersQuery());
        }

        [HttpGet]
        [Route("GetAllOffers")]
        public async Task<BaseResponse<List<GetAllOffersDto>?>> GetAllOffers()
        {
            return await _mediator.Send(new GetAllOffersQuery());
        }

        [HttpGet]
        [Route("GetOfferDetails")]
        public async Task<BaseResponse> GetOfferDetails()
        {
            return new BaseResponse(true);
        }

        [HttpPost]
        [Route("AddOffer")]
        public async Task<BaseResponse<int?>> AddOffer([FromBody] AddOfferCommand request)
        {
            return await _mediator.Send(request);
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
