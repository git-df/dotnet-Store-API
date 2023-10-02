using Application.Contracts.Persistence;
using Application.Functions.Offer.Commands.AddOffer;
using Application.Functions.Offer.Queries.GetOfferDetails;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.UpdateOffer
{
    public class UpdateOfferHandler : IRequestHandler<UpdateOfferCommand, BaseResponse>
    {
        private readonly IOfferRepository _offerRepository;

        public UpdateOfferHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public async Task<BaseResponse> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOfferValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse(false, null, validationResult);

            var offer = await _offerRepository.GetById(request.Id);

            if (offer == null)
            {
                return new BaseResponse(false, "Bad offer id");
            }

            (
                offer.Name,
                offer.Description,
                offer.Price,
                offer.ImageUrl
            ) = (
                request.Name ?? string.Empty,
                request.Description ?? string.Empty,
                request.Price ?? 0,
                request.ImageUrl
            );

            var updatedOffer = await _offerRepository.Update(offer);

            if (updatedOffer == null)
            {
                return new BaseResponse(false, "Something went wrong :(");
            }

            return new BaseResponse(true, "Offer updated");
        }
    }
}
