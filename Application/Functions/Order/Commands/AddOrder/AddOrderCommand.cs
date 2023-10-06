using Application.Responses;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<BaseResponse<int?>>
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? StreetWithNumber { get; set; }
        public string? PostalCode { get; set; }
        public List<AddOrderItems> Items { get; set; } = new List<AddOrderItems>();
    }

    public class AddOrderItems
    {
        public int Count { get; set; }
        public int OfferId { get; set; }
    }
}
