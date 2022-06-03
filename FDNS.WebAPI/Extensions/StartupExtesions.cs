using FDNS.Common.Configuration;
using FDNS.Domain.Interfaces;
using FDNS.Domain.Models;
using FDNS.Infrastructure.NamecheapAPI.Interfaces;
using FDNS.Infrastructure.NamecheapAPI.Services;
using FDNS.Persistence.Repositories;
using FDNS.Services.Abstractions.Base;
using FDNS.Services.Abstractions.Security;
using FDNS.Services.Base;
using FDNS.Services.Security;
using FNDS.Persistence;
using FNDS.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FDNS.WebAPI.Extensions
{
    public static class StartupExtesions
    {
        public static IServiceCollection SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opts =>
            {
                opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Description = "JWT authorization header using Bearer scheme",
                    Scheme = "Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header
                });

                opts.SwaggerDoc("v1", new OpenApiInfo { Title = "FluentDNS", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                var requirement = new OpenApiSecurityRequirement
                {
                    { securityScheme, new List<string>() }
                };

                opts.AddSecurityRequirement(requirement);
            });
            return services;
        }
        public static IServiceCollection SetupConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<NamecheapApiConfiguration>(configuration.GetSection("NamecheapAPI"));
            services.Configure<JWTConfiguration>(configuration.GetSection("JWT"));
            services.Configure<EconomyConfiguration>(configuration.GetSection("Economy"));

            return services;
        }

        public static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<INamecheapDomainsService, NamecheapDomainsService>();
            services.AddScoped<INamecheapDnsService, NamecheapDnsService>();
            services.AddScoped<INamecheapUsersService, NamecheapUsersService>();

            return services;
        }

        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IDomainsRepository, DomainsRepository>();
            services.AddScoped<IDomainContactsRepository, DomainContactsRepository>();
            services.AddScoped<IUserContactsRepository, UserContactsRepository>();

            services.AddScoped<IProductionDomainPricingRepository, ProductionDomainPricingRepository>();
            services.AddScoped<ISandboxDomainPricingRepository, SandboxDomainPricingRepository>();
            services.AddScoped<IBaseTLDRepository<SandboxTLD>, BaseTLDRepository<SandboxTLD>>();
            services.AddScoped<IBaseTLDRepository<ProductionTLD>, BaseTLDRepository<ProductionTLD>>();

            services.AddScoped<IDomainsService, DomainsService>();
            services.AddScoped<IDomainContactsService, DomainContactsService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IUserContactsService, UserContactsService>();
            services.AddScoped<IBaseDomainPricingService<SandboxDomainPrice>, SandboxDomainPricingService>();
            services.AddScoped<IBaseTldService<SandboxTLD>, BaseTldService<SandboxTLD>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(typeof(StartupExtesions), typeof(DomainsService));
            services.AddIdentity<User, IdentityRole<Guid>>(opts =>
            {
                opts.SignIn.RequireConfirmedEmail = false;
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
                opts.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<FdnsDbContext>()
                .AddSignInManager<SignInManager<User>>()
                .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection SetupSecurity(this IServiceCollection services, IConfiguration config)
        {
            var jwtConfig = config.GetSection("JWT").Get<JWTConfiguration>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer  = true,
                    ValidIssuer = jwtConfig.Issuer
                };
            });

            var corsOrigins = new List<string>();
            config.GetSection("AllowedOrigins").Bind(corsOrigins);

            services.AddCors(opts => 
            {
                opts.AddPolicy("CorsPolicy", policy => 
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(corsOrigins.ToArray());
                });
            });
            return services;
        }
    }
}
