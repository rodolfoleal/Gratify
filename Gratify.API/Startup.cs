using CrossSolar.Repository;
using Gratify.Business;
using Gratify.Exceptions;
using Gratify.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Gratify.API
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GratifyDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Gratify.API")));
            services.AddTransient<IWishListBusinesss, WishListBusiness>();
            services.AddTransient<IItemBusinesss, ItemBusiness>();
            services.AddTransient<IUserBusinesss, UserBusiness>();
            services.AddTransient<IWishListRepository, WishListRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            //Adds MVC
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, GratifyDbContext gratifyDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseHttpStatusCodeExceptionMiddleware();
            }
            else
            {
                app.UseHttpStatusCodeExceptionMiddleware();
                app.UseExceptionHandler();
            }

            gratifyDbContext.EnsureSeedDataForContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                // cfg.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
            });

            app.UseMvc();
        }
    }
}