﻿using Diplom.libs.db.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

            var transport_driver1 = new TransportsDrivers { TransportsDriverId = 1 }; //Drivers = Drivers.FirstOrDefault(p => p.DriverId == 1), Transports = Transports.FirstOrDefault(p => p.TransportId == 1) };
            var transport_driver2 = new TransportsDrivers { TransportsDriverId = 2 }; //Drivers = Drivers.FirstOrDefault(p => p.DriverId == 2), Transports = Transports.FirstOrDefault(p => p.TransportId == 2) };
            var transport_driver3 = new TransportsDrivers { TransportsDriverId = 3 }; //Drivers = Drivers.FirstOrDefault(p => p.DriverId == 3), Transports = Transports.FirstOrDefault(p => p.TransportId == 3) };
            var transport_driver4 = new TransportsDrivers { TransportsDriverId = 4 }; //Drivers = Drivers.FirstOrDefault(p => p.DriverId == 4), Transports = Transports.FirstOrDefault(p => p.TransportId == 4) };

            modelBuilder.Entity<TransportsDrivers>().HasData(transport_driver1, transport_driver2, transport_driver3, transport_driver4);

            modelBuilder.Entity<Storages>().HasData(
                new Storages { StorageId = 1, Name = "Склад 1", Location = "проезд М-1, 1Ж, Старый Оскол, Белгородская область", Accommodation = 2000 },
                new Storages { StorageId = 2, Name = "Склад 2", Location = "Куйбышевское шоссе, 25литЯ, Рязань", Accommodation = 1000 }
            );

            modelBuilder.Entity<Products>().HasData(
                new Products { ProductId = 1, Name = "Стекло", Volume = 20 },
                new Products { ProductId = 2, Name = "Стекло", Volume = 10 }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders { OrderId = 1, Tonnage = 20, NameCompany = "СтеклоПро", NumberPhone = "89194326274", PointReception = "Академическая улица, 3, Белгород" },
                new Orders { OrderId = 2, Tonnage = 5, NameCompany = "ОПТстекло", NumberPhone = "89305398213", PointReception = "Ливенская улица, 78, Орёл" }
            );
        }
    }
}
