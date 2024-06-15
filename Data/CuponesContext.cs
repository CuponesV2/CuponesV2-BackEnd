using Microsoft.EntityFrameworkCore;

namespace Cupones.Data
{
    public class CuponesContext : DbContext
    {
        public CuponesContext(DbContextOptions<CuponesContext> options) : base(options) {}
    }
}