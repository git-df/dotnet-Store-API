using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class StoreDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "todo";
                        break;
                    case EntityState.Modified:
                        entry.Entity.Updated = DateTime.Now;
                        entry.Entity.UpdatedBy = "todo";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Offer>(x => 
            {
                x.Property(x => x.Price)
                    .HasColumnType("decimal(19,4)");
            });

            builder.Entity<OrderItem>(x =>
            {
                x.Property(x => x.Price)
                    .HasColumnType("decimal(19,4)");
            });

            builder.Entity<Payment>(x =>
            {
                x.Property(x => x.Price)
                    .HasColumnType("decimal(19,4)");
            });

            base.OnModelCreating(builder);

            var roles = new List<IdentityRole<Guid>>()
            {
                new IdentityRole<Guid>()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = new Guid("f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"),
                    ConcurrencyStamp = "f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"
                },
                new IdentityRole<Guid>()
                {
                    Name = "Employee",
                    NormalizedName = "Employee",
                    Id = new Guid("ee2f3920-917c-4599-9941-a93b7376e6cf"),
                    ConcurrencyStamp = "ee2f3920-917c-4599-9941-a93b7376e6cf"
                },
                new IdentityRole<Guid>()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = new Guid("96ae491d-ab67-489c-ab00-8eb57d05f11a"),
                    ConcurrencyStamp = "96ae491d-ab67-489c-ab00-8eb57d05f11a"
                }
            };

            var admin = new AppUser()
            {
                Id = new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                UserName = "sa",
                Email = "sa",
                NormalizedUserName = "sa".ToUpper(),
                NormalizedEmail = "sa".ToUpper(),
                FirstName = "sa",
                LastName = "sa"
            };

            admin.PasswordHash = new PasswordHasher<AppUser>().HashPassword(admin, "Haslo123!");

            var adminRoles = new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                {
                    RoleId = roles[0].Id,
                    UserId = admin.Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = roles[1].Id,
                    UserId = admin.Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = roles[2].Id,
                    UserId = admin.Id
                }
            };

            builder.Entity<IdentityRole<Guid>>().HasData(roles);
            builder.Entity<AppUser>().HasData(admin);
            builder.Entity<IdentityUserRole<Guid>>().HasData(adminRoles);
        }
    }
}
