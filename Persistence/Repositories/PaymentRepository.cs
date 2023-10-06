using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }

        new public async Task<List<Payment>> GetAll()
        {
            return await _storeDbContext.Payments
                .Include(x => x.AppUser)
                .ToListAsync();
        }

        public async Task<Payment?> GetPaymentByOrderId(int orderId)
        {
            return await _storeDbContext.Payments
                .FirstOrDefaultAsync(x => x.OrderId == orderId);
        }

        public async Task<List<Payment>> GetPaymentsByUserId(Guid userId)
        {
            return await _storeDbContext.Payments
                .Where(x => x.AppUserId == userId)
                .ToListAsync();
        }
    }
}
