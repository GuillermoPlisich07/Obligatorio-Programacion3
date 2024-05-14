using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
         
            // ARTICULO
            modelBuilder.Entity<Articulo>()
                .HasKey(a => a.id); // Definir la clave primaria

            modelBuilder.Entity<Articulo>()
                .Property(a => a.id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Configurar la generación automática del ID

            modelBuilder.Entity<Articulo>()
                .Property(a => a.nombre)
                .IsRequired()
                .HasMaxLength(200) // Establecer la longitud máxima del nombre
                .HasAnnotation("MinLength", 10); // Establecer la longitud mínima del nombre

            modelBuilder.Entity<Articulo>()
                .Property(a => a.descripcion)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Articulo>()
                .Property(a => a.codigoProveedor)
                .IsRequired()
                .HasAnnotation("MinLength", 10);

            modelBuilder.Entity<Articulo>()
                .Property(a => a.precioPublico)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Articulo>()
                .Property(a => a.stock);
            
            
            //USUARIO

            // Configurar el índice único en la propiedad email
            modelBuilder.Entity<Usuario>().HasIndex(u => u.email).IsUnique();

            // Configurar las propiedades de la clase Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.id); // Establecer la clave primaria

            modelBuilder.Entity<Usuario>()
                .Property(u => u.id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Configurar la auto-generación de valores

            modelBuilder.Entity<Usuario>()
                .Property(u => u.email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.apellido)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Usuario>()
            .Ignore(e => e.password);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.passwordHash)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");


            //CLIENTE

            modelBuilder.Entity<Cliente>()
            .HasKey(c => c.id); // Establecer la clave primaria

            modelBuilder.Entity<Cliente>()
                .Property(c => c.id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Configurar la auto-generación de valores

            modelBuilder.Entity<Cliente>()
                .Property(c => c.razonSocial)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.RUT)
                .IsRequired()
                .HasColumnType("int");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.ciudad)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.numPuerta)
                .IsRequired()
                .HasColumnType("int");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.calle)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.distancia)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Lineas

            modelBuilder.Entity<Linea>()
            .HasKey(l => l.id); // Establecer la clave primaria

            modelBuilder.Entity<Linea>()
                .Property(l => l.id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Configurar la auto-generación de valores

            modelBuilder.Entity<Linea>()
                .Property(l => l.cantUnidades)
                .IsRequired();

            modelBuilder.Entity<Linea>()
                .Property(l => l.preUnitarioVigente)
                .IsRequired()
                .HasColumnType("decimal(18, 2)"); // Configurar el tipo de columna

            modelBuilder.Entity<Linea>()
                .HasOne(l => l.articulo) // Establecer la relación con la clase Articulo
                .WithMany()
                .IsRequired(); // Especificar que es obligatoria la relación

            modelBuilder.Entity<Linea>()
            .HasCheckConstraint("CHK_cantUnidades_mayor_cero", "cantUnidades > 0");



            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=ObligatorioP3_Marzo2024; Integrated Security=SSPI;");
        }
    }
}
