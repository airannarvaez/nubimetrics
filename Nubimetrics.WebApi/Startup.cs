using Microsoft.AspNetCore.Builder;

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
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UsePathBase("/MyRestfulApp");
         
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());

        }
    }
}
