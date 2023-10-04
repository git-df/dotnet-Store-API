using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetPaymentsHistory
{
    public class GetPaymentsHistoryHandler : IRequestHandler<GetPaymentsHistoryQuery, BaseResponse<List<GetPaymentsHistoryDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentsHistoryHandler(
            IMapper mapper,
            IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse<List<GetPaymentsHistoryDto>?>> Handle(GetPaymentsHistoryQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetPaymentsByUserId(request.UserId);

            if (payments == null || !payments.Any())
                return new BaseResponse<List<GetPaymentsHistoryDto>?>(false, "No payments");

            return new BaseResponse<List<GetPaymentsHistoryDto>?>(
                _mapper.Map<List<GetPaymentsHistoryDto>>(payments), true);
        }
    }
}
