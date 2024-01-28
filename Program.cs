using Microsoft.EntityFrameworkCore;
using ProyectoManager.Services;
using ProyectoManager.Components;
using ProyectoManager.DAL;

namespace ProyectoManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            //leer la connection string llamada ConStr que pusimos en appsettings.json
            var ConStr = builder.Configuration.GetConnectionString("ConStr");

            //inyectar el contextopara que este disponible en los constructores donde los solicitemos
            builder.Services.AddDbContext<Contexto>(Options => Options.UseSqlite(ConStr));

            //inyecté las Services
            builder.Services.AddScoped<PrioridadesService>();
            builder.Services.AddScoped<ClientesService>();
            builder.Services.AddScoped<TicketsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery(); //evitar hackeos de tokens

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
