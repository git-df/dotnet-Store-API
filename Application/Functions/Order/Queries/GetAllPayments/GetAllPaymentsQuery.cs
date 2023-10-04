using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetAllPayments
{
    public class GetAllPaymentsQuery : IRequest<BaseResponse<List<GetAllPaymentsDto>?>>
    {
    }
}
