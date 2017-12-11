using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Validations;
using AutoMapper;
using Business.Dtos;
using Business.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence;
using Repositories;

namespace Api
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
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<ITemperatureServices, TemperatureServices>();
            services.AddTransient<ITemperatureRepository, TemperatureRepository>();

            var connection = @"Server = .\SQLEXPRESS; Database=Temperature.Development; Trusted_Connection = true;";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddTemperatureRecordValidation>()); ;

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
