using Microsoft.EntityFrameworkCore;
using Cupones.Data;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;
using Cupones.Dtos;
using AutoMapper;

namespace Cupones.Services
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly CuponesContext _context;
        private readonly IMapper _mapper;

        public PurchaseRepository(CuponesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }
    }
}

