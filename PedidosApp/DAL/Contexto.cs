using Microsoft.EntityFrameworkCore;
using PedidosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApp.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Suplidores> suplidores { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Ordenes> ordenes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\stive\OneDrive\Escritorio\BD\Ordenes1.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 1,
                Nombre = "Rica",
               

            });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 2,
                Nombre = "Induveca",


            });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 3,
                Nombre = "Nestle",


            });
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId=1,
                Descripcion="Salami",
                Costo= Convert.ToInt32(450.00),
                Inventario=10


            });
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 2,
                Descripcion = "ListaMilk",
                Costo = Convert.ToInt32(60.00),
                Inventario = 40


            });
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 3,
                Descripcion = "Naranja sin azucar",
                Costo = Convert.ToInt32(45.00),
                Inventario = 10


            });
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 4,
                Descripcion = "Carnation",
                Costo = Convert.ToInt32(60.00),
                Inventario = 15


            });
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 5,
                Descripcion = "Leche Condenzada",
                Costo = Convert.ToInt32(45.00),
                Inventario = 7
            });
        }
    }
}
