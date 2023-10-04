using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetOrders
{
    public class GetOrdersDto
    {
        public int Id { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime Created { get; set; }
        public Guid PaymentId { get; set; }
        public string? PaymentStatus { get; set; }
        public decimal? Price { get; set; }
    }
}
