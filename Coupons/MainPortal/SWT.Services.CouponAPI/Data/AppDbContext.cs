using Microsoft.EntityFrameworkCore;
using SWT.Services.CouponAPI.Models;
using System.Runtime.CompilerServices;

namespace SWT.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                 CouponId=1,
                 CouponName="10AFF",
                 DiscountAmount=1000,
                 MinAmount=10,
                 CouponCode="AXSDSD"
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponName = "10AFC",
                DiscountAmount = 2000,
                MinAmount = 10,
                CouponCode = "SDSDSD"
            });

        }
    }
}
