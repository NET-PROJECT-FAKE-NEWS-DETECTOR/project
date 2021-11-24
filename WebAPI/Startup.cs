using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence.Context;
using Persistence.v1;
using Persistence.v1.Persistence.v1;
using System;
using System.Linq;
using System.Reflection;

namespace WebAPI
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

            services.AddControllers();
            services.AddApiVersioning();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddControllersWithViews();
            services.AddDbContext<DataSetContext>
                (options => options.UseMySQL(Configuration.GetConnectionString("MyConnection")));

            services.AddScoped<IAdminAuthRepository, AdminAuthRepository>();
            services.AddScoped<IDataSetRepository, DataSetRepository>();
            services.AddHttpContextAccessor();
            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            //services.AddScoped<IApplicationContext, DataSetContext>();
            // register implementations related to repository/generic implementation
            // services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            //services.AddTransient<IDataSetRepository, DataSetRepository>();
            // services.AddTransient<IAdminAuthRepository, AdminAuthRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
