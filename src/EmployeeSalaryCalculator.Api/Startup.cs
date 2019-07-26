using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Services;
using EmployeeSalaryCalculator.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeSalaryCalculator.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeApiRepository>();
            services.AddScoped<IEmployeeFactory, EmployeeFactory>();
            services.AddHttpClient("EmployeeService", e =>
                {
                    e.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/");
                });
            services.AddCors(o => o.AddPolicy("EmployeesCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EmployeesCorsPolicy");
            app.UseMvc();
        }
    }
}
