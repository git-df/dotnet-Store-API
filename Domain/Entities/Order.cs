using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : AuditableEntity
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.New;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string StreetWithNumber { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public Guid? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public Guid? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
