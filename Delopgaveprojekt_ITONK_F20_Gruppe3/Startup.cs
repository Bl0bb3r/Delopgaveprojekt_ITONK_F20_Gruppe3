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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddControllersWithViews();

            // inspiration from video; "https://www.youtube.com/watch?time_continue=482&v=o1qxhe6Fnu0&feature=emb_logo"
            var host = Configuration["SQLSERVER_GRP3"]; //Need to determine host
            var password = Configuration["F20ITONK"];

            var connectionString =
                $"Data Source ={host}; User ID = SA; Password = {password}; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            services.AddDbContext<AppDbContext.AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            /*
            services.AddDbContext<AppDbContext.AppDbContext>(options =>
                {
                    options.UseMySql($"Server={host}; Uid=root; Pwd={password}; Port={port};Database=haandvaerkerdb");
                }
            );
            services.AddScoped<IHaandvaerkerRepository, HaandvaerkerRepository>();
            services.AddScoped<IVaerktoejRepository, VaerktoejRepository>();
            services.AddScoped<IVaerktoejskasseRepository, VaerktoejskasseRepository>();*/
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
            /*
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            context.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    
            });*/
            }
    }
}
