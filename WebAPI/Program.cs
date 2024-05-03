
using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICUAlta<DTOArticulo>, CUAltaArticulo>();
            builder.Services.AddScoped<ICUAlta<DTOCliente>, CUAltaCliente>();
            builder.Services.AddScoped<ICUAlta<Linea>, CUAltaLinea>();
            builder.Services.AddScoped<ICUAlta<Pedido>, CUAltaPedido>();
            builder.Services.AddScoped<ICUAlta<DTOUsuario>, CUAltaUsuario>();
            builder.Services.AddScoped<ICUBaja, CUBajaCliente>();
            builder.Services.AddScoped<ICUBaja, CUBajaLinea>();
            builder.Services.AddScoped<ICUBaja, CUBajaPedido>();
            builder.Services.AddScoped<ICUBaja, CUBajaUsuario>();
            builder.Services.AddScoped<ICUBuscarPorId<DTOCliente>, CUBuscarCliente>();
            builder.Services.AddScoped<ICUListadoOrdenado<DTOArticulo>, CUListadoArticuloOrdenado>();
            builder.Services.AddScoped<ICUListado<Pedido>, CUListadoPedido>();
            builder.Services.AddScoped<ICUListado<DTOUsuario>, CUListadoUsuario>();
            builder.Services.AddScoped<ICUModificar<DTOCliente>, CUModificarCliente>();
            builder.Services.AddScoped<ICUModificar<Linea>, CUModificarLinea>();
            builder.Services.AddScoped<ICUModificar<DTOUsuario>, CUModificarUsuario>();
            builder.Services.AddScoped<ICULogin<DTOUsuario>, CULoginUsuario>();
            builder.Services.AddScoped<ICUBuscarPorId<DTOUsuario>, CUBuscarUsuario>();
            builder.Services.AddScoped<ICUListado<DTOCliente>, CUListadoCliente>();
            builder.Services.AddScoped<ICUBuscarRutOMonto<DTOCliente>, CUBusquedaClientesMonto>();

            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            builder.Services.AddScoped<IRepositorioLinea, RepositorioLinea>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            builder.Services.AddDbContext<LibreriaContext>();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
