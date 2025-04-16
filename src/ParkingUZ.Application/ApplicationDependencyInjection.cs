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
using ParkingUZ.Application.Services.Interface;
using ParkingUZ.Application.Services.Implement;
using ParkingUZ.Application.MappingProfiles;
using ParkingUZ.Application.Models.User;
using ParkingUZ.Application.Helpers.GenerateJwt;

namespace ParkingUZ.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, 
            IWebHostEnvironment env, IConfiguration configuration)
        {
            services.AddServices(env);

            services.RegisterAutoMapper();

            services.RegisterCashing();

            services.Configure<JwtOption>(configuration.GetSection("JwtSettings"));
            return services;
        }

        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IParkingSpotService, ParkingSpotService>();
            services.AddScoped<IParkingSubscriptionService, ParkingSubscriptionService>();
            services.AddScoped<IParkingZoneService, ParkingZoneService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IQRCodeService, QRCodeService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
            services.AddScoped<IValidator<CreateUserModel>, UserForCreationDtoValidator>();
            services.AddScoped<IValidator<ResetPasswordModel>, ResetPasswordValidator>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }

        private static void RegisterCashing(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
