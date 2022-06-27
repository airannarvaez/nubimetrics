using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Nubimetrics.Repositories;

namespace Nubimetrics.WebApi
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            string baseUrl = Configuration["baseUrl"];
            services.AddTransient(p => new ApiClientFactory(new Uri(baseUrl)));
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<NubimetricsContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UsePathBase("/MyRestfulApp");
         
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());

        }
    }
}
