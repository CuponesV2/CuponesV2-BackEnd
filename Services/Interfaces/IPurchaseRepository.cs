using Microsoft.AspNetCore.Mvc;
using Cupones.Models;
using Cupones.Dtos;

namespace Cupones.Services
{
    public interface IPurchaseRepository
    {
        public IEnumerable<Purchase> GetAll();
        public Purchase GetOne(int id);
        public void Create(Purchase purchase);
        public IActionResult Update(int id, PurchaseDto purchaseDto);
    }
}

