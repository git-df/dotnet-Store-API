using Application.Contracts.Persistence;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.ChangeOfferActive
{
    public class ChangeOfferActiveHandler : IRequestHandler<ChangeOfferActiveCommand, BaseResponse>
    {
        private readonly IOfferRepository _offerRepository;

        public ChangeOfferActiveHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse> Handle(ChangeOfferActiveCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.GetById(request.Id);

            if (offer == null)
            {
                return new BaseResponse(false, "Bad offer id");
            }

            if (request.Active && string.IsNullOrWhiteSpace(offer.ImageUrl))
            {
                return new BaseResponse(false, "Add a photo first");
            }

            offer.Active = request.Active;

            var updatedOffer = await _offerRepository.Update(offer);

            if (updatedOffer == null)
            {
                return new BaseResponse(false, "Something went wrong :(");
            }

            return new BaseResponse(true, "Offer updated");
        }
    }
}
