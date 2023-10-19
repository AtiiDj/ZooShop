using Microsoft.EntityFrameworkCore;
using System.Data;
using ZooShop.Models;

namespace ZooShop.Data
{
    public class AppDbContext : DbContext
    {
        private const string connectionString = @"Server=DESKTOP-66BR1CT\MSSQLSERVER01; Initial Catalog=ZooShop; Integrated Security=true; Trusted_Connection=true";


        public DbSet<Animal> Animals { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Town> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Shop)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.ShopId)
                .OnDelete(DeleteBehavior.Restrict);
                      

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Clients)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.Towns)
                .WithMany(t => t.Clients)
                .HasForeignKey(c => c.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shop>()
                .HasOne(s => s.Towns)
                .WithMany(t => t.Shops)
                .HasForeignKey(s => s.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
