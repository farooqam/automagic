using System;
using System.IO;
using System.Reflection;
using Automagic.Apis.Vehicle.VehicleCommand.Models;
using Automagic.Apis.Vehicle.VehicleCommand.Models.Validators;
using Automagic.Apis.Vehicle.VehicleCommand.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace Automagic.Apis.Vehicle.VehicleCommand
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddFluentValidation();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Vehicle Command API",
                    Description = "This API allows you to add vehicles to your tenant.",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Automagic LLC",
                        Email = "api@automagic.com",
                        Url = "https://automagic.developer.com/apis"
                    },
                    License = new License
                    {
                        Name = "Automagic License 2.0",
                        Url = "https://automagic.developer.com/apis/license"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.TryAddScoped<IValidator<AddVehicleRequest>, AddVehicleRequestValidator>();
            services.TryAddScoped<IVehicleIdService, VehicleIdService>();
            services.TryAddScoped<IVehicleDataService, FakeVehicleDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle Command API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
