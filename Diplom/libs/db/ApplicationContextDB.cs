using Diplom.libs.db.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.libs.db
{
    public class ApplicationContextDB : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Drivers> Drivers { get; set; } = null!;
        public DbSet<Storages> Storages { get; set; } = null!;
        public DbSet<Transports> Transports { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Transportations> Transportations { get; set; } = null!;
        public DbSet<TransportsDrivers> TransportsDrivers { get; set; } = null!;

        public ApplicationContextDB() 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(@"Server=COMPUTER\SQLEXPRESS;Database=DiplomDB;Trusted_Connection=True;TrustServerCertificate=true;");
            }
            catch (Exception e)
            { Console.WriteLine(e); };
            
        }
    }
}
