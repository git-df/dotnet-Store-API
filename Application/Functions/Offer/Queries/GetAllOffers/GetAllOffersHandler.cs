using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Functions.Offer.Queries.GetAllOffers
{
    public class GetAllOffersHandler : IRequestHandler<GetAllOffersQuery, BaseResponse<List<GetAllOffersDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;

        public GetAllOffersHandler(
            IMapper mapper,
            IOfferRepository offerRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
        }

        public async Task<BaseResponse<List<GetAllOffersDto>?>> Handle(GetAllOffersQuery request, CancellationToken cancellationToken)
        {
            var offers = await _offerRepository.GetAll();

            if (offers == null || !offers.Any())
            {
                return new BaseResponse<List<GetAllOffersDto>?>(false, "No offers");
            }

            return new BaseResponse<List<GetAllOffersDto>?>(
                _mapper.Map<List<GetAllOffersDto>>(offers), true);
        }
    }
}
