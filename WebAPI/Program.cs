
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

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICUAlta<DTOPedidoExpress>, CUAltaPedidoExpress>();
            builder.Services.AddScoped<ICUAlta<DTOPedidoComun>, CUAltaPedidoComun>();
            //builder.Services.AddScoped<ICUListado<DTOPedido>, CUListadoPedido>();
            //builder.Services.AddScoped<ICUBaja, CUBajaPedido>();

            //TODO
            builder.Services.AddScoped<ICUModificar<Linea>, CUModificarLinea>();
            builder.Services.AddScoped<ICUAlta<Linea>, CUAltaLinea>();
            builder.Services.AddScoped<ICUBaja, CUBajaLinea>();

            builder.Services.AddScoped<ICUModificar<DTOUsuario>, CUModificarUsuario>();
            builder.Services.AddScoped<ICULogin<DTOUsuario>, CULoginUsuario>();
            builder.Services.AddScoped<ICUBuscarPorId<DTOUsuario>, CUBuscarUsuario>();
            builder.Services.AddScoped<ICUAlta<DTOUsuario>, CUAltaUsuario>();
            builder.Services.AddScoped<ICUListado<DTOUsuario>, CUListadoUsuario>();
            builder.Services.AddScoped<ICUBaja, CUBajaUsuario>();

            builder.Services.AddScoped<ICUModificar<DTOCliente>, CUModificarCliente>();
            builder.Services.AddScoped<ICUListado<DTOCliente>, CUListadoCliente>();
            builder.Services.AddScoped<ICUBuscarRutOMonto<DTOCliente>, CUBusquedaClientesMonto>();
            builder.Services.AddScoped<ICUAlta<DTOCliente>, CUAltaCliente>();
            builder.Services.AddScoped<ICUBuscarPorId<DTOCliente>, CUBuscarCliente>();
            builder.Services.AddScoped<ICUBaja, CUBajaCliente>();

            builder.Services.AddScoped<ICUBuscarPorId<DTOImpuesto>, CUBuscarImpuesto>();
            builder.Services.AddScoped<ICUModificar<DTOImpuesto>, CUModificarImpuesto>();

            builder.Services.AddScoped<ICUAlta<DTOArticulo>, CUAltaArticulo>();
            builder.Services.AddScoped<ICUListado<DTOArticulo>, CUListadoArticulo>();
            builder.Services.AddScoped<ICUBuscarPorId<DTOArticulo>, CUBuscarArticulo>();
            builder.Services.AddScoped<ICUListadoOrdenado<DTOArticulo>, CUListadoArticuloOrdenado>();

            builder.Services.AddScoped<ICUListado<DTOPedido>, CUListadoPedidoAnulados>();

            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            builder.Services.AddScoped<IRepositorioLinea, RepositorioLinea>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioImpuesto, RepositorioImpuesto>();
            builder.Services.AddScoped<IRepositorioImpuesto, RepositorioImpuesto>();
            builder.Services.AddScoped<IRepositorioPedidoComun, RepositorioPedidoComun>();
            builder.Services.AddScoped<IRepositorioPedidoExpress, RepositorioPedidoExpress>();

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
