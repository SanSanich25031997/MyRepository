using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FoodDelivery.Models;
using FoodDelivery.Data;
using FoodDelivery.Data.Interfaces;
using FoodDelivery.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery
{
    public class Startup
    {
        private IConfigurationRoot configurationString;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            configurationString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FoodDeliveryDbContext>(options => options.UseSqlServer(configurationString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProducts, ProductRepository>();
            services.AddTransient<IAllCompanies, CompanyRepository>();
            services.AddTransient<IAllOrders, OrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => FoodDeliveryCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews(mvcOptions =>
            {
                mvcOptions.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{Id?}");
                routes.MapRoute(name: "companyFilter", template: "Products/{action}/{company?}", defaults: new { Controller = "Product", action = "List" });
            });

            using(var scope = app.ApplicationServices.CreateScope())
            {
                FoodDeliveryDbContext context = scope.ServiceProvider.GetRequiredService<FoodDeliveryDbContext>();
                DbObjects.Initial(context);
            }
        }
    }
}
