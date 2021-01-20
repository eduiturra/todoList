using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoList.DAL.Repositories;
using AutoMapper;
using TodoList.DAL;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Helpers;
using TodoList.DAL.UnitOfWork;
using TodoList.BLL.Services;
using Microsoft.OpenApi.Models;

namespace TodoList.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped(typeof(IRespositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITareasService, TareasService>();
            services.AddScoped<IUsuariosService, UsuariosService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Prueba Evaluación {groupName}",
                    Version = groupName,
                    Description = "Todo List API",
                    Contact = new OpenApiContact
                    {
                        Name = "Eduardo Iturra S.",
                        Email = "edu.iturra.analista@gmail.com"
                    }
                });
            });
        }
    }
}
