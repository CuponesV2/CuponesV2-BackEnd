using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using AutoMapper;
using Cupones.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace Cupones.Services
{
    public class CouponHistoryRepository : ICouponHistoryRepository
    {
        private readonly CuponesContext _context;

        public CouponHistoryRepository(CuponesContext context)
        {
            _context = context;
        }

         public void Create(int CouponId, CouponHistory couponHistory)
{
    // Encuentra el cupón existente por ID.
    var coupon = _context.Coupons.Find(CouponId);
    if (coupon == null)
    {
        throw new Exception("Cupón no encontrado.");
    }

    // Asigna la fecha actual a Change_date.
    couponHistory.Change_date = DateOnly.Parse(DateTime.Now.ToString());

    // Determina el Old_Value basado en el Field_Changed.
    switch (couponHistory.Field_changed)
    {
        case "Name":
            couponHistory.Old_value = coupon.Name;
            break;
        case "Description":
            couponHistory.Old_value = coupon.Description;
            break;
        case "Start_date":
            couponHistory.Old_value = coupon.Start_date.ToString();
            break;
        case "End_date":
            couponHistory.Old_value = coupon.End_date.ToString();
            break;
        // Agrega casos para otros campos que puedan cambiar.
        default:
            throw new Exception("Campo a cambiar no reconocido.");
    }

    // Configura el ID del cupón en el objeto couponHistory.
    couponHistory.CouponId = CouponId;

    // Agrega el nuevo historial de cupón a la base de datos.
    _context.CouponHistories.Add(couponHistory);

    // Guarda los cambios en la base de datos.
    _context.SaveChanges();
}

    }
}

