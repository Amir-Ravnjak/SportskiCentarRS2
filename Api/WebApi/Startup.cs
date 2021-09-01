using CleanArchitecture.Application;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Infrastructure;
using SportskiCentarRS2.WebApi.Hubs;
using SportskiCentarRS2.WebApi.Services;
using SportskiCentarRS2.WebUI.Filters;
using System.Linq;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddHostedService<ProvjeraUplataRezervacijaService>();
            services.AddHttpContextAccessor();
            services.AddControllers(options=>options.Filters.Add<ApiExceptionFilterAttribute>())
                    .AddFluentValidation()
                    .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Sportski centar";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            }); 

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection(); 
            app.UseOpenApi();

            app.UseSwaggerUi3(settings => {
                settings.Path = "";
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHub<NotifikacijeHub>("/api/notifikacijeHub");
            });
        }
    }
}
