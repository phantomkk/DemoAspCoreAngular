using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Business;
using Demo.DataAccess.DataAccessObjects;
using Demo.DataAccess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DemoProject
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
            services.AddDbContext<WebDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyDemoDb")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerDocument();
            services.AddLogging();
            services.AddScoped(typeof(IVozImageService), typeof(VozImageService));

            ConfigDependencyInjection(services);
            ConfigAutomapper(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            } 
            app.UseHttpsRedirection();// Register the Swagger generator and the Swagger UI middlewares
             

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Voz}/{action=Index}/{id?}");
            });
        }

        private void ConfigDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<WebDbContext>, WebUnitOfWork<WebDbContext>>();
            services.AddScoped<IProductRepository>(x => new ProductRepository(x.GetService<IUnitOfWork<WebDbContext>>()));
            services.AddScoped<IProductService, ProductService>(); 
        }
        private void ConfigAutomapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles.MappingProfiles>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
