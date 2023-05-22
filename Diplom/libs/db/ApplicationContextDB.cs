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
            //Database.EnsureDeleted();
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users { UserId = 1, Email = "admin@admin.com", Name = "Admin", Surname = "Admin", Login = "admin@admin.com", Password = "21232f297a57a5a743894a0e4a801fc3", IsAdmin = true },      
                new Users { UserId = 2, Email = "manager@manager.com", Name = "Manager", Surname = "Manager", Login = "manager@manager.com", Password = "1d0258c2440a8d19e716292b231e3190", IsManager = true },
                new Users { UserId = 3, Email = "karina1@mail.ru", Name = "Карина", Surname = "Овчинникова", Login = "karina1@mail.ru", Password = "a37b2a637d2541a600d707648460397e" }
            );
        }
    }
}
