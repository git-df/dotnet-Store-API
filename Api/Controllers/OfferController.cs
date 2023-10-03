using Application.Functions.Offer.Commands.AddOffer;
using Application.Functions.Offer.Commands.ChangeOfferActive;
using Application.Functions.Offer.Commands.ChangeOfferImage;
using Application.Functions.Offer.Commands.DeleteOffer;
using Application.Functions.Offer.Commands.UpdateOffer;
using Application.Functions.Offer.Queries.GetAllOffers;
using Application.Functions.Offer.Queries.GetOfferDetails;
using Application.Functions.Offer.Queries.GetOffers;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Employee, Admin")]
        [Route("GetAllOffers")]
        public async Task<BaseResponse<List<GetAllOffersDto>?>> GetAllOffers()
        {
            return await _mediator.Send(new GetAllOffersQuery());
        }

        [HttpGet]
        [Authorize(Roles = "Employee, Admin")]
        [Route("GetOfferDetails/{id}")]
        public async Task<BaseResponse<GetOfferDetailsDto?>> GetOfferDetails(int id)
        {
            return await _mediator.Send(new GetOfferDetailsQuery() { Id = id});
        }

        [HttpPost]
        [Authorize(Roles = "Employee, Admin")]
        [Route("AddOffer")]
        public async Task<BaseResponse<int?>> AddOffer([FromBody] AddOfferCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Authorize(Roles = "Employee, Admin")]
        [Route("UpdateOffer")]
        public async Task<BaseResponse> UpdateOffer([FromBody] UpdateOfferCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        [Authorize(Roles = "Employee, Admin")]
        [Route("ChangeOfferActive")]
        public async Task<BaseResponse> ChangeOfferActive([FromBody] ChangeOfferActiveCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        [Authorize(Roles = "Employee, Admin")]
        [Route("ChangeOfferImage")]
        public async Task<BaseResponse> ChangeOfferImage([FromBody] ChangeOfferImageCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Authorize(Roles = "Employee, Admin")]
        [Route("DeleteOffer/{id}")]
        public async Task<BaseResponse> DeleteOffer(int id)
        {
            return await _mediator.Send(new DeleteOfferCommand() { Id = id });
        }
    }
}
