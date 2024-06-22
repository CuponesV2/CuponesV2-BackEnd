
using Cupones.Dtos;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cupones.Services
{
    public interface IPurchaseRepository
    {
        public IEnumerable<Purchase> GetAll();
        public Purchase GetOne(int id);
        public void Create(Purchase purchase);
    }
}

