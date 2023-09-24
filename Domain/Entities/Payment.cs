using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : AuditableEntity
    {
        public Guid Id { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.New;
        public decimal Price { get; set; }

        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public Guid? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
