using Microsoft.EntityFrameworkCore;
using SignalRApiProject.DAL.Entity;

namespace SignalRApiProject.DAL.Concrete
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-K2BKEMA;Database=DBSignalRApi;integrated security=true;trust server certificate=true");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
