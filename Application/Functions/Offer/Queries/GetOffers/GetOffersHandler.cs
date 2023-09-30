using Application.Contracts.Persistence;
using Application.Functions.Offer.Queries.GetAllOffers;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Queries.GetOffers
{
    public class GetOffersHandler : IRequestHandler<GetOffersQuery, BaseResponse<List<GetOffersDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public GetOffersHandler(
            IMapper mapper,
            IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse<List<GetOffersDto>?>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
        {
            var offers = await _offerRepository.GetAllActive();

            if (offers == null || !offers.Any())
            {
                return new BaseResponse<List<GetOffersDto>?>(false, "No offers");
            }

            return new BaseResponse<List<GetOffersDto>?>(
                _mapper.Map<List<GetOffersDto>>(offers), true);
        }
    }
}
