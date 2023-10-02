using Application.Contracts.Persistence;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.ChangeOfferImage
{
    public class ChangeOfferImageHandler : IRequestHandler<ChangeOfferImageCommand, BaseResponse>
    {
        private readonly IOfferRepository _offerRepository;

        public ChangeOfferImageHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }
        public async Task<BaseResponse> Handle(ChangeOfferImageCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.GetById(request.Id);

            if (offer == null)
            {
                return new BaseResponse(false, "Bad offer id");
            }

            offer.ImageUrl = request.ImageUrl;

            var updatedOffer = await _offerRepository.Update(offer);

            if (updatedOffer == null)
            {
                return new BaseResponse(false, "Something went wrong :(");
            }

            return new BaseResponse(true, "Offer updated");
        }
    }
}
