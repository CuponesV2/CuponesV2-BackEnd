using Microsoft.EntityFrameworkCore;
using Cupones.Models;

namespace Cupones.Data
{
    public class CuponesContext : DbContext
    {
        public CuponesContext(DbContextOptions<CuponesContext> options) : base(options) {}

        public DbSet<Role> Roles { get; set; }
        public DbSet<MarketingUser> MarketingUsers { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}