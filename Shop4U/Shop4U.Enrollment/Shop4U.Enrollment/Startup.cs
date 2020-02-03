using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop4U.Enrollment.Models;
using Shop4U.Enrollment.Repositories;
using Shop4U.Enrollment.Services;

namespace Shop4U.Enrollment
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

            services.AddDbContextPool<EnrollmentDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("Shop4UDBConnection")));


            //services.AddScoped<ISuperAdministratorRepository, SuperAdministratorRepository>();
            //services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            //services.AddScoped<IBusinessPersonelRepository, BusinessPersonelRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<IDistributorRepository, DistributorRepository>();
            services.AddControllers();

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
