using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Functions.Offer.Commands.AddOffer
{
    public class AddOfferCommandHandler : IRequestHandler<AddOfferCommand, BaseResponse<int?>>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public AddOfferCommandHandler(
            IMapper mapper, 
            IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse<int?>> Handle(AddOfferCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddOfferCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return new BaseResponse<int?>(false, null, validationResult);

            var offer = _mapper.Map<Domain.Entities.Offer>(request);

            offer.Active = false;

            var newOffer = await _offerRepository.Add(offer);

            if (newOffer == null)
            {
                return new BaseResponse<int?>(false, "Something went wrong :(");
            }

            return new BaseResponse<int?>(newOffer.Id, true);
        }
    }
}
