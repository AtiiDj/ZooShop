using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZooShop.Models;

namespace Data.ZooShop
{
    public class AppDbContext : DbContext
    {
        private const string connectionString = @"Server=DESKTOP-66BR1CT\MSSQLSERVER01; Initial Catalog=ZooShop; Integrated Security=true; Trusted_Connection=true";
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
