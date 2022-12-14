using CasosUso.InterfacesManejadores;
using CasosUso.Manejadores;
using Dominio.InterfacesRepositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositorios;

namespace AppMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Servicios de sesion
            services.AddSession();

            // Configurar las inyecciones necesarias
            //plantas
            services.AddScoped<IManejadorPlanta, ManejadorPlanta>();
            services.AddScoped<IRepositorioPlanta, RepositorioPlanta>();


            //tipoPlantas
            services.AddScoped<IRepositorioTipoPlanta, RepositorioTipoPlanta>();
            services.AddScoped<IManejadorTipoPlanta, ManejadorTipoPlanta>();

            //tipoIluminacion
            services.AddScoped<IRepositorioTipoIluminacion, RepositorioTipoIluminacion>();
            services.AddScoped<IManejadorIluminacion, ManejadorIluminacion>();
           
            //busqueda
            services.AddScoped<IManejadorBusqueda, ManejadorBusqueda>();

            //usuarios
            services.AddScoped<IManejadorUsuario, ManejadorUsuario>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            //compras
            services.AddScoped<IManejadorCompra, ManejadorCompras>();
            services.AddScoped<IRepositorioCompra, RepositorioCompra>();

            //base de datos
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("miConexionEF")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // uso de sesion
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Usuarios}/{action=Index}/{id?}");
            });
        }
    }
}