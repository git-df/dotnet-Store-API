using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Queries.GetPaymentsHistory
{
    public class GetPaymentsHistoryDto
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public decimal Price { get; set; }
        public int? OrderId { get; set; }
    }
}
