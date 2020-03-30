using Delopgaveprojekt_ITONK_F20_Gruppe3.AppDbContext;
using Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            // inspiration from video; "https://www.youtube.com/watch?time_continue=482&v=o1qxhe6Fnu0&feature=emb_logo"
            var host = Configuration["ITONKGRP3_SQLSERVER_SERVICE_HOST"];
            var password = Configuration["MSSQL_SA_PASSWORD"];

            var connectionString =
                $"Data Source ={host}; User ID = SA; Password = {password}; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            services.AddDbContext<AppDbContext.AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc( x => x.EnableEndpointRouting=false).SetCompatibilityVersion(CompatibilityVersion.Latest);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext.AppDbContext context)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    //app.UseHsts();
                }

                app.UseStaticFiles();
                app.UseCookiePolicy();
                context.Database.Migrate();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
    }
}
