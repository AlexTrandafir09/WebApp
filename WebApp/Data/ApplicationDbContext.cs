using Microsoft.EntityFrameworkCore;
using WebApp.Models.Echipa;
namespace WebApp.Data
{
    public class ApplicationDbContext: DbContext
    {   
        public DbSet<Echipa> Echipe { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
