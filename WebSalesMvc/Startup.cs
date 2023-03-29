﻿using Microsoft.EntityFrameworkCore;
using WebSalesMvc.Data;

namespace WebSalesMvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebSalesMvcContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("WebSalesMvcContext"), new MySqlServerVersion(new Version(8, 0, 32))));

            services.AddScoped<SeedingService>();

            // Add services to the container.
            services.AddControllersWithViews();
        }

        public void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //seeding.Seed();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }

            //public void Configure(IApplicationBuilder app, IWebHostEnvironment environment, SeedingService seedingService)
            //{
            //    if (environment.IsDevelopment())
            //    {
            //        app.UseDeveloperExceptionPage();
            //        seedingService.Seed();
            //    }
            //    else
            //    {
            //        app.UseExceptionHandler("/Home/Error");
            //        app.UseHsts();
            //    }

            //    app.UseHttpsRedirection();
            //    app.UseStaticFiles();
            //    app.UseCookiePolicy();

            //    app.UseMvc(routes =>
            //    {
            //        routes.MapRoute(
            //            name: "default",
            //            template: "{controller=Home}/{action=Index}/{id?}");
            //    });
            //}
    }
}
