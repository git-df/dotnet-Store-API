using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string OfferUrl { get; set; } = string.Empty;

        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
