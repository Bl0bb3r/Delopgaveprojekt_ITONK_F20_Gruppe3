using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3
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

            // inspiration from video; "https://www.youtube.com/watch?time_continue=482&v=o1qxhe6Fnu0&feature=emb_logo"
            var host = "host";
            var port = "5000";
            var password = "secret";

            services.AddDbContext<AppDbContext.AppDbContext>(options =>
                {
                    options.UseMySql($"Server={host}; Uid=root; Pwd={password}; Port={port};Database=haandvaerkere");
                }
            );
            services.AddScoped<IHaandvaerkerRepository, HaandvaerkerRepository>();
            services.AddScoped<IVaerktoejRepository, VaerktoejRepository>();
            services.AddScoped<IVaerktoejskasseRepository, VaerktoejskasseRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Delopgaveprojekt_ITONK_F20_Gruppe3.AppDbContext.AppDbContext context)
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

            app.UseRouting();

            app.UseAuthorization();

            context.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    
            });
        }
    }
}
