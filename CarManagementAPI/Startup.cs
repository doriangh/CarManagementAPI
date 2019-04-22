using CarManagement.Core.Interfaces;
using CarManagement.Infrastructure.Data;
using CarManagement.Infrastructure.Repositories;
using CarManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CarManagementAPI
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<AppDbContext>();
            services.AddScoped<DbContext, AppDbContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ISessionService, SessionService>();
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "CarManagement", Version = "v1" }); });

            services.AddMvc();

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
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarManagement V1"); });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
