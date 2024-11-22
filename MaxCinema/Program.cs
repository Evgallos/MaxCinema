using MaxCinema.Data;
using MaxCinema.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MaxCinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var connectionString = builder.Configuration
                .GetConnectionString("CloudConnection");
                //.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MCinemaContext>(o => o.UseSqlServer(connectionString));

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddSession(o => o.IdleTimeout = TimeSpan.FromMinutes(20));
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
