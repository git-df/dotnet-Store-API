using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetAllOrders
{
    public class GetAllOrdersDto
    {
        public int Id { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime Created { get; set; }
        public string? PaymentStatus { get; set; }
        public decimal? Price { get; set; }
        public string? Email { get; set; }
        public Guid? AppUserId { get; set; }
    }
}
