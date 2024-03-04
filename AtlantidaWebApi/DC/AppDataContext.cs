using AtlantidaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlantidaWebApi.DC
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
    }
}
