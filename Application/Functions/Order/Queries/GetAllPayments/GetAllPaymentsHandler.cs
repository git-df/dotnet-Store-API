using Application.Contracts.Persistence;
using Application.Functions.Order.Queries.GetPaymentsHistory;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetAllPayments
{
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, BaseResponse<List<GetAllPaymentsDto>?>>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetAllPaymentsHandler(
            IMapper mapper,
            IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<BaseResponse<List<GetAllPaymentsDto>?>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentRepository.GetAll();

            if (payments == null || !payments.Any())
                return new BaseResponse<List<GetAllPaymentsDto>?>(false, "No payments");

            return new BaseResponse<List<GetAllPaymentsDto>?>(
                _mapper.Map<List<GetAllPaymentsDto>>(payments), true);
        }
    }
}
