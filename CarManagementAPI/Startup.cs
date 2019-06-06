using CarManagement.Core.Entities;
using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;
using CarManagement.Infrastructure.Repositories;
using CarManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Swashbuckle.AspNetCore.Swagger;

namespace CarManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPredictionEnginePool<ModelInput, ModelOutput>()
                .FromFile("MLModels/MLModel.zip");

            services.AddDbContext<AppDbContext>();
            services.AddScoped<DbContext, AppDbContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ICarDetailRepository, CarDetailRepository>();
            services.AddTransient<ICarPriceRepository, CarPriceRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ICarDetailService, CarDetailService>();
            services.AddScoped<ICarPriceService, CarPriceService>();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "CarManagement", Version = "v1"}); });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarManagement V1"); });

            app.UseMvc();
        }
    }
}