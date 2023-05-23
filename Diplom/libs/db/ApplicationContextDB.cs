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

            modelBuilder.Entity<Transports>().HasData(
                new Transports { TransportId = 1, Name = "Fuso Fighter", Brand = "Mitsubishi", LoadCapacity = 5000, YearProd = 2001 },
                new Transports { TransportId = 2, Name = "Fuso Fighter", Brand = "Mitsubishi", LoadCapacity = 10000, YearProd = 2010 },
                new Transports { TransportId = 3, Name = "Fuso Fighter", Brand = "Mitsubishi", LoadCapacity = 15000, YearProd = 2011 },
                new Transports { TransportId = 4, Name = "Fuso Fighter", Brand = "Mitsubishi", LoadCapacity = 20000, YearProd = 2012 }
            );

            modelBuilder.Entity<Drivers>().HasData(
                new Drivers { DriverId = 1, Name = "Константин", Surname = "Констов", Patronymic = "Леонидович", DrivingExperience = "10", DateAdoption = Convert.ToDateTime("10.12.2008") },
                new Drivers { DriverId = 2, Name = "Даниил", Surname = "Давыдов", Patronymic = "Макарович", DrivingExperience = "10", DateAdoption = Convert.ToDateTime("10.12.2008") },
                new Drivers { DriverId = 3, Name = "Филип", Surname = "Быков", Patronymic = "Максимович", DrivingExperience = "10", DateAdoption = Convert.ToDateTime("10.12.2008") },
                new Drivers { DriverId = 4, Name = "Антон", Surname = "Сорокин", Patronymic = "Адамович", DrivingExperience = "10", DateAdoption = Convert.ToDateTime("10.12.2008") }
            );

            modelBuilder.Entity<TransportsDrivers>().HasData(
                new TransportsDrivers { TransportsDriverId = 1 },
                new TransportsDrivers { TransportsDriverId = 2 },
                new TransportsDrivers { TransportsDriverId = 3 },
                new TransportsDrivers { TransportsDriverId = 4 }
            );
        }
    }
}
