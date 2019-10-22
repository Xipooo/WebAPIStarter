using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPIStarter.Services.CustomerService;
using WebAPIStarterData;

namespace WebAPIStarter
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
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddTransient<ICustomerService, InMemoryDatabaseCustomerService>();
            services.AddDbContext<WebAPIStarterContext>(options =>
            {
                options.UseSqlite(
                    Configuration.GetConnectionString("WebAPIStarterDatabase"),
                    m => m.MigrationsAssembly("WebAPIStarter")
                );
            });

            // services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            new DatabaseSeed(app).Initialize();
            app.UseHttpsRedirection();
            // app.UseRouting();
            app.UseAuthorization();
            app.UseMvc();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
        }
    }
}
