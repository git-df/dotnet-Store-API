using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetOrderDetails
{
    public class GetOrderDetailsDto
    {
        public int? Id { get; set; }
        public OrderStatus Status { get; set; }
        public Guid? AppUserId { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? StreetWithNumber { get; set; }
        public string? PostalCode { get; set; }
        public Guid? PaymantId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal? Price { get; set; }
        public List<GetOrderDetailsItems> Items { get; set; } = new List<GetOrderDetailsItems>();
    }

    public class GetOrderDetailsItems
    {
        public int? Id { get; set; }
        public int? Count { get; set; }
        public decimal? Price { get; set; }
        public string? ProductName { get; set; }
        public string? OfferUrl { get; set; }
    }
}
