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

        public DbSet<MarketplaceUser> MarketplaceUsers { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<CouponUsage> CouponUsages { get; set; }

        public DbSet<CouponHistory> CouponHistories { get; set; }

        public DbSet<PurchaseCoupon> PurchaseCoupons { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }
    }
}