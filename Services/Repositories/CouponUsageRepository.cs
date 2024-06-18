using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using AutoMapper;
using Cupones.Dtos;
using Microsoft.AspNetCore.Mvc;
using System; 

namespace Cupones.Services
{
    public class CouponUsageRepository : ICouponUsageRepository
    {
       private readonly CuponesContext _context;

       public CouponUsageRepository(CuponesContext context)
       {
           _context = context;
       } 

       public void CouponUsage(Coupon coupon, MarketingUser marketingUser, CouponUsage couponUsage)
       {
           couponUsage.Coupon = coupon;
           couponUsage.MarketingUser = marketingUser;
           couponUsage.Usage_date = DateOnly.Parse(DateTime.Now.ToString());
           _context.CouponUsages.Add(couponUsage);
           _context.SaveChanges();
       }
    }
}