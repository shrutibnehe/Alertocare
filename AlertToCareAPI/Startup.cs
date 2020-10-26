using System.Diagnostics.CodeAnalysis;
using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlertToCareAPI
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
       // public IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        private IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
                //options.UseSqlite(_config.GetConnectionString("Data source= C:/Users/320107932/OneDrive - Philips/Bootcamp/Changes/AlertToCareAPI/AlertToCare.db"));
            });
            
            services.AddScoped<IIcuConfigurationRepository, IcuConfigrationRepository>();
            services.AddScoped<IPatientRepo, PatientRepository>();
            services.AddScoped<IMonitoringRepo, MonitorinRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
