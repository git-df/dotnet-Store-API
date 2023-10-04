using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }

        public async Task<List<Order>> GetOrdersByUserId(Guid userId)
        {
            return await _storeDbContext.Orders
                .Include(x => x.Payment)
                .Where(x => x.AppUserId == userId)
                .ToListAsync();
        }

        new public async Task<List<Order>> GetAll()
        {
            return await _storeDbContext.Orders
                .Include(x => x.Payment)
                .ToListAsync();
        }
    }
}
