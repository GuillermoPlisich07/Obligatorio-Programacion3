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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //ACÁ ES DONDE PONDRÍAMOS NUESTRO CÓDIGO DE "FLUENT API" PARA CONFIGURAR
        //    //COSAS DE NUESTRO MODELO DE ENTIDES QUE PUEDEN TENER IMPACTO A NIVEL DE LA BD (ESQUEMAS)
        //    //SUSTITUYE O COMPLEMENTA LAS DATA ANNOTATIONS
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=ObligatorioP3_Marzo2024; Integrated Security=SSPI;");
        }
    }
}
