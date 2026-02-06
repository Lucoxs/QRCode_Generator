using Microsoft.EntityFrameworkCore;
using QRCode_Generator.Models;

namespace QRCode_Generator.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }

        public DbSet<Mapping> Mapping { get; set; }
    }
}
