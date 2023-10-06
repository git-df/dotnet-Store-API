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
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }

        public async Task<AppUser?> GetByEmail(string email)
        {
            return await _storeDbContext.AppUsers.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
