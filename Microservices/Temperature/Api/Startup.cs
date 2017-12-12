using Api.Validations;
using AutoMapper;
using Business.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Repositories;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddTransient<ITemperatureService, TemperatureService>();
            services.AddTransient<ITemperatureRepository, TemperatureRepository>();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddTemperatureRecordValidation>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Temperature Microservice", Version = "v1" });
            });

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Temperature Microservice");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
