using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
