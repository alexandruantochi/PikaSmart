using Api.Validations;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddTransient<IDatabaseContext, DatabaseContext>();
            services.AddTransient<ITemperatureRepository, TemperatureRepository>();

            services.AddTransient<INotificationContext, NotificationContext>();
            services.AddTransient<INotificationRepository, NotificationRepository>();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            var notifConnection = Configuration.GetConnectionString("NotificationConnection");

            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("Temperature Database"));
            services.AddDbContext<NotificationContext>(options => options.UseInMemoryDatabase("Notification Database"));
          /*  services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connection));
            services.AddDbContext<NotificationContext>(opt => opt.UseSqlServer(notifConnection));*/

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddTemperatureRecordValidation>());

            services.AddMediatR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Temperature Microservice", Version = "v1" });
            });

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Temperature Microservice");
                });

                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
