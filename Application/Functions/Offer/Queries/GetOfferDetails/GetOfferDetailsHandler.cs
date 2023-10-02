using Application.Contracts.Persistence;
using Application.Functions.Offer.Queries.GetOffers;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Queries.GetOfferDetails
{
    public class GetOfferDetailsHandler : IRequestHandler<GetOfferDetailsQuery, BaseResponse<GetOfferDetailsDto?>>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public GetOfferDetailsHandler(
            IMapper mapper,
            IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse<GetOfferDetailsDto?>> Handle(GetOfferDetailsQuery request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.GetById(request.Id);

            if (offer == null)
            {
                return new BaseResponse<GetOfferDetailsDto?>(false, "Bad offer id");
            }

            return new BaseResponse<GetOfferDetailsDto?>(
                _mapper.Map<GetOfferDetailsDto>(offer), true);
        }
    }
}
