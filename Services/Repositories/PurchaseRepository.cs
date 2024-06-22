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

        public IEnumerable<Purchase> GetAll()
        {
            return _context.Purchases
                .Include(pc => pc.MarketplaceUser)
                .ToList();
        }

        public Purchase GetOne(int id)
        {
            var purchase = _context.Purchases
                .Include(pc => pc.MarketplaceUser)
                .FirstOrDefault(p => p.Id == id);

            return purchase;
        }

        public void Create(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }

        public IActionResult Update(int id, PurchaseDto purchaseDto)
        {
            var purchase = _context.Purchases.Find(id);
            if (purchase == null)
            {
                return new NotFoundResult();
            }
            _mapper.Map(purchaseDto, purchase);
            _context.SaveChanges();
            
            return new OkObjectResult(purchase);
        }
    }
}

