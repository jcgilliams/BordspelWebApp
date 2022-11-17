using BordspelWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BordspelWebApp.Areas.Data;

namespace BordspelWebApp.Data
{
    public class BordspelWebAppContext : IdentityDbContext<Gebruiker>
    {
        public BordspelWebAppContext(DbContextOptions<BordspelWebAppContext> option) : base(option)
        {
        }

        public DbSet<Bordspel> Bordspellen { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Rol> Rollen { get; set; }
        public DbSet<Uitgeverij> Uitgeverijen { get; set; }
        public DbSet<Collectie> Collecties { get; set; }
        public DbSet<Uitgave> Uitgaven { get; set; }
        public DbSet<BordspelPersoon> BordspelPersonen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("BordspelWebApp");

            modelBuilder.Entity<Bordspel>().ToTable("Bordspel");
            modelBuilder.Entity<Persoon>().ToTable("Persoon");
            modelBuilder.Entity<Rol>().ToTable("Rol");
            modelBuilder.Entity<Uitgeverij>().ToTable("Uitgeverij");

            modelBuilder.Entity<Collectie>().ToTable("Collectie");
            modelBuilder.Entity<Uitgave>().ToTable("Uitgave");
            modelBuilder.Entity<BordspelPersoon>().ToTable("BordspelPersoon");

            modelBuilder.Entity<Collectie>()   
              .HasOne(c => c.Bordspel)   
              .WithMany(b => b.Collecties)
              .HasForeignKey(c => c.BordspelId) 
              .IsRequired();

/*            modelBuilder.Entity<Collectie>()
              .HasOne(c => c.Gebruiker)
              .WithMany(g => g.Collecties)
              .HasForeignKey(c => c.GebruikersId) // nog na te zien!
              .IsRequired();*/

            modelBuilder.Entity<Uitgave>()
                .HasOne(u => u.Bordspel)
                .WithMany(b => b.Uitgaves)
                .HasForeignKey(u => u.BordspelId)
                .IsRequired();

            modelBuilder.Entity<Uitgave>()
                .HasOne(u => u.Uitgeverij)
                .WithMany(x => x.Uitgaves)
                .HasForeignKey(u => u.UitgeverijId)
                .IsRequired();

            modelBuilder.Entity<BordspelPersoon>()
                .HasOne(bp => bp.Bordspel)
                .WithMany(b => b.BordspelPersonen)
                .HasForeignKey(bp => bp.BordspelId)
                .IsRequired();
            
            modelBuilder.Entity<BordspelPersoon>()
                .HasOne(bp => bp.Rol)
                .WithMany(r => r.BordspelPersonen)
                .HasForeignKey(bp => bp.RolId)
                .IsRequired();

            modelBuilder.Entity<BordspelPersoon>()
                .HasOne(bp => bp.Persoon)
                .WithMany(p => p.BordspelPersonen)
                .HasForeignKey(bp => bp.PersoonId)
                .IsRequired();
        }
    }
}
