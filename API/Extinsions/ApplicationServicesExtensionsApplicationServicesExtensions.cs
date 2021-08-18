using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Presistence;

namespace API.Extinsions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
               services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddDbContext<DataContext>(opt=>opt.UseSqlite(
                "Data Source=Reactivities.db"
)
            );
            services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                              builder =>
                              {
                                  builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                              });
        });
        services.AddMediatR(typeof(List.Handler).Assembly);
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        return services;
        }
    }
}