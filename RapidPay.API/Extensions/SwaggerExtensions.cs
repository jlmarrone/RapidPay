using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using RapidPay.API.Authentication;

namespace RapidPay.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basic Authorization", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Please, to test, use the following: username = admin and password = admin123 for Admin role or username = guest and password = guest123 for role Guest."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>("BasicAuthentication", null);
        }
    }
}
