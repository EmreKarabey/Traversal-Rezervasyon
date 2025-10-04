using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL.Entity;

namespace SignalRApi.DAL.Concrete
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-K2BKEMA;Database=DBMyVisit;Integrated Security=true;Trust Server Certificate=True");

        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
