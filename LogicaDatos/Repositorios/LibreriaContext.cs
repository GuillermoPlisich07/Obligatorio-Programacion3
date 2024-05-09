using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoComun> PedidoComunes { get; set; }
        public DbSet<PedidoExpress> PedidosExpress { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //// Configuración para la clase Articulo
            //modelBuilder.Entity<Articulo>()
            //    .HasKey(a => a.id); // Definir la clave primaria

            //modelBuilder.Entity<Articulo>()
            //    .Property(a => a.id)
            //    .IsRequired()
            //    .ValueGeneratedOnAdd(); // Configurar la generación automática del ID

            
            //modelBuilder.Entity<Articulo>()
            //    .Property(a => a.nombre)
            //    .IsRequired()
            //    .HasMaxLength(200) // Establecer la longitud máxima del nombre
            //    .HasAnnotation("MinLength", 10); // Establecer la longitud mínima del nombre

            //modelBuilder.Entity<Articulo>()
            //    .Property(a => a.descripcion)
            //    .IsRequired()
            //    .HasMaxLength(200);

            //modelBuilder.Entity<Articulo>()
            //    .Property(a => a.codigoProveedor)
            //    .IsRequired()
            //    .HasAnnotation("MinLength", 10);


            //modelBuilder.Entity<Articulo>()
            //    .Property(a => a.precioPublico)
            //    .HasColumnType("decimal(18, 2)");

            //modelBuilder.Entity<Articulo>()
            //    .Property(a => a.stock);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=ObligatorioP3_Marzo2024; Integrated Security=SSPI;");
        }
    }
}
