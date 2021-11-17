using Application.Common.Interfaces;
using Infrastructure;
using Infrastructure.DelegatingHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Application.Common.Behaviours;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace Vacation_Inc_
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var applicationAssmebly = Assembly.Load("Application");

            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssembly(applicationAssmebly);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vacation_Inc_", Version = "v1" });
            });

            services.AddTransient<ApiKeyHandler>();
            services.AddHttpClient(HttpClientConstants.CurrencyLayer, c =>
            {
                c.BaseAddress = new Uri("http://api.currencylayer.com/");
            }).AddHttpMessageHandler<ApiKeyHandler>();

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(applicationAssmebly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vacation_Inc_ v1"));
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
