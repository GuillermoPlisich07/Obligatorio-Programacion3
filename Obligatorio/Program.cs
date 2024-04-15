using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;

namespace Obligatorio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICUAlta<Articulo>, CUAltaArticulo>();
            builder.Services.AddScoped<ICUAlta<Cliente>, CUAltaCliente>();
            builder.Services.AddScoped<ICUAlta<Linea>, CUAltaLinea>();
            builder.Services.AddScoped<ICUAlta<Pedido>, CUAltaPedido>();
            builder.Services.AddScoped<ICUAlta<Usuario>, CUAltaUsuario>();
            builder.Services.AddScoped<ICUBaja, CUBajaCliente>();
            builder.Services.AddScoped<ICUBaja, CUBajaLinea>();
            builder.Services.AddScoped<ICUBaja, CUBajaPedido>();
            builder.Services.AddScoped<ICUBaja, CUBajaUsuario>();
            builder.Services.AddScoped<ICUBuscarPorId<Cliente>, CUBuscarCliente>();
            builder.Services.AddScoped<ICUListado<Articulo>, CUListadoArticulo>();
            builder.Services.AddScoped<ICUListado<Pedido>, CUListadoPedido>();
            builder.Services.AddScoped<ICUModificar<Cliente>, CUModificarCliente>();
            builder.Services.AddScoped<ICUModificar<Linea>, CUModificarLinea>();
            builder.Services.AddScoped<ICUModificar<Usuario>, CUModificarUsuario>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
