﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebApp.Models;
using MyWebApp.Repository;

namespace MyWebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            //arquivos para build
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //conexão com o banco de dados
            var sqlConnection = _configuration.GetConnectionString("MyWebAppDb");
            services.AddDbContext<Context>(options =>
            options.UseMySql(sqlConnection, b => b.MigrationsAssembly("MyWebApp")));

            services.AddMvc();

            //mapeamento de interfaces
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}