using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingUZ.Application.DataTransferObject.Authentication;
using ParkingUZ.Application.Validators;
using ParkingUZ.DataAccess;
using ParkingUZ.Shared.Services.Impl;
using ParkingUZ.Shared.Services;
using Microsoft.Extensions.Hosting;

namespace ParkingUZ.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, 
            IWebHostEnvironment env)
        {
            services.AddServices(env);

            services.RegisterAutoMapper();

            services.RegisterCashing();
            return services;
        }

        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IValidator<LoginDTO>, LoginDtoValidator>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }

        private static void RegisterCashing(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
