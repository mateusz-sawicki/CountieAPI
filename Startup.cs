using Microsoft.EntityFrameworkCore;
using CountieAPI.Entities;

namespace CountieAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<CountieDbContext>();
            services.AddScoped<CountieDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CountieSeeder seeder)
        {
            seeder.Seed();
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
