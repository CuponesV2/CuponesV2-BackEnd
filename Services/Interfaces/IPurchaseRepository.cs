
using Cupones.Dtos;
using Cupones.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cupones.Services
{
    public interface IPurchaseRepository
    {
        public void Create(Purchase purchase);
    }
}

