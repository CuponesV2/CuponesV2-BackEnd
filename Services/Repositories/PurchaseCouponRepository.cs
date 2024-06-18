using Cupones.Data;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cupones.Services;

public class PurchaseCouponRepository : IPurchaseCouponRepository
{
    private readonly CuponesContext _context;
    private readonly IMapper _mapper;

    public PurchaseCouponRepository(CuponesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<PurchaseCoupon> GetAll()
    {
        return _context.PurchaseCoupons
            .Include(pc => pc.Purchase)
            .Include(pc => pc.Coupon)
            .ToList();
    }

    public PurchaseCoupon GetOne(int id)
    {
        return _context.PurchaseCoupons
            .Include(pc => pc.Purchase)
            .Include(pc => pc.Coupon)
            .FirstOrDefault(pc => pc.Id == id);
    }
}