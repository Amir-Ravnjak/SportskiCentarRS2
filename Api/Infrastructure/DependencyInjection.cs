using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportskiCentarRS2.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SportskiCentarRS2.Application.Common.Interfaces;
using SportskiCentarRS2.Domain.Entities;
using SportskiCentarRS2.Infrastructure.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SportskiCentarRS2.Infrastructure.Services;
using Stripe;

namespace SportskiCentarRS2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services
                .AddDefaultIdentity<Korisnik>(config => {
                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 4;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.SignIn.RequireConfirmedAccount = false;
                })
                .AddRoles<KorisnickaUloga>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();

            StripeConfiguration.ApiKey = configuration.GetValue<string>("StripeSecretKey");
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
                {
                    config.RequireHttpsMetadata = false;
                    var secretBytes = Encoding.UTF8.GetBytes(configuration.GetValue<string>("SecretKeyJWT"));
                    var key = new SymmetricSecurityKey(secretBytes);
            
            
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = configuration.GetValue<string>("JWTIssuer"),
                        ValidAudience = configuration.GetValue<string>("JWTAudience"),
                        IssuerSigningKey = key
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
