using DNZ.EmployeeManagement.GrpcServer.Data;
using DNZ.EmployeeManagement.GrpcServer.GrpcServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNZ.EmployeeManagement.GrpcServer
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer("Server=.;Database=DNZEmployeeManagement;Trusted_Connection=True;MultipleActiveResultSets=True");
            });

            services.AddGrpc();
        }

    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<UserServiceGrpcServer>();
            });
        }
    }
}
