using Microsoft.EntityFrameworkCore;
using WebApp.Models.Baza_sportiva;
using WebApp.Models.Echipa;
using WebApp.Models.Echipa_liga;
using WebApp.Models.Jucator;
using WebApp.Models.Liga;
namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Echipa> echipe { get; set; }
        public DbSet<Liga> ligi { get; set; }

        public DbSet<Echipa_liga> echipa_liga { get; set; }

        public DbSet<Jucator> jucatori { get; set; }

        public DbSet<Baza_sportiva> baze_sportive { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Echipa_liga>().HasKey(el => new {el.Echipa_id, el.Liga_id});

            modelBuilder.Entity<Echipa_liga>()
                .HasOne(e => e.echipa)
                .WithMany(el => el.echipe_ligi)
                .HasForeignKey(l => l.Liga_id);


            modelBuilder.Entity<Echipa_liga>()
                .HasOne(l => l.liga)
                .WithMany(el => el.echipe_ligi)
                .HasForeignKey(e => e.Echipa_id);

            modelBuilder.Entity<Jucator>()
                .HasOne(e => e.echipa)
                .WithMany(j => j.jucatori)
                .HasForeignKey(e => e.echipa_id);

            modelBuilder.Entity<Echipa>()
                .HasOne(b => b.baza)
                .WithOne(e => e.echipa)
                .HasForeignKey<Baza_sportiva>(b => b.echipa_id);
        }

                
    }
}
