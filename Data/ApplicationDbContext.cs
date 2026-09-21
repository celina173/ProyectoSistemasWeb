using Microsoft.EntityFrameworkCore;
using pruebacontroladores.Models.Entities;
using System;

namespace pruebacontroladores.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<StockDeposito> StockDepositos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evitar delete cascade
            modelBuilder.Entity<Producto>()
                .HasOne(m => m.Categoria)
                .WithMany(m => m.Productos)
                .HasForeignKey(m => m.idCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            // Datos semilla de prueba para las tablas
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { id = 1, Nombre = "Alimentos", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null },
                new Categoria { id = 2, Nombre = "Limpieza", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null },
                new Categoria { id = 3, Nombre = "Lacteos", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null }
            );

            modelBuilder.Entity<Deposito>().HasData(
                new Deposito { id = 1, Nombre = "Depósito General", Ubicacion = "Planta baja", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null },
                new Deposito { id = 2, Nombre = "Depósito Principal", Ubicacion = "Planta alta", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null },
                new Deposito { id = 3, Nombre = "Depósito Secundario", Ubicacion = "Planta baja", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null }
            );

            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor { id = 1, Nombre = "Proveedor A", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null }
            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { id = 1, Nombre = "Cliente A", Activo = true, CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = null }
            );
        }
    }
}