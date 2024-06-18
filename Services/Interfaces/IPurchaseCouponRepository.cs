using Cupones.Dtos;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cupones.Services
{
    public interface IPurchaseCouponRepository
    {
         public IEnumerable<PurchaseCoupon> GetAll();
          public PurchaseCoupon GetOne(int id);

    }
}