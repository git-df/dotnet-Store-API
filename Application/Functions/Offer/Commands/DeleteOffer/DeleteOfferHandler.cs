using Application.Contracts.Persistence;
using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.DeleteOffer
{
    public class DeleteOfferHandler : IRequestHandler<DeleteOfferCommand, BaseResponse>
    {
        private readonly IOfferRepository _offerRepository;

        public DeleteOfferHandler(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.GetById(request.Id);

            if (offer == null)
            {
                return new BaseResponse(false, "Bad offer id");
            }

            await _offerRepository.Delete(offer);

            return new BaseResponse(true, "Offer deleted");
        }
    }
}
