using Application.Contracts.Persistence;
using Application.Functions.Offer.Queries.GetAllOffers;
using Application.Responses;
using AutoMapper;
using DF.Query.Pagination.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Queries.GetOffers
{
    public class GetOffersHandler : IRequestHandler<GetOffersQuery, BaseResponse<PaginatedList<GetOffersDto>?>>
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

        public async Task<BaseResponse<PaginatedList<GetOffersDto>?>> Handle(GetOffersQuery request, 
            CancellationToken cancellationToken)
        {
            var offers = await _offerRepository.GetAllActive(request.Pagination, cancellationToken);

            if (offers == null || !offers.Items.Any())
            {
                return new BaseResponse<PaginatedList<GetOffersDto>?>(false, "No offers");
            }

            return new BaseResponse<PaginatedList<GetOffersDto>?>(
                offers, true);
        }
    }
}
