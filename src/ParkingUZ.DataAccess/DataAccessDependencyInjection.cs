using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingUZ.DataAccess.Authentication;
using ParkingUZ.DataAccess.Identity;
using ParkingUZ.DataAccess.Persistence;
using ParkingUZ.DataAccess.Repositories.Implement;
using ParkingUZ.DataAccess.Repositories.Interface;
using ParkingUZ.Shared.Services;
using ParkingUZ.Shared.Services.Impl;

namespace ParkingUZ.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddIdentity();
            services.AddRepositories();
            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();
            services.AddScoped<IParkingSubscriptionRepository, ParkingSubscriptionRepository>();
            services.AddScoped<IParkingZoneRepository, ParkingZoneRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IQRCodeRepository, QRCodeRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ISubscriptionPlanRepository, SubscriptionPlanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

            /*if (databaseConfig == null)
            {
                throw new InvalidOperationException("Database configuration section is missing.");
            }

            if (!databaseConfig.UseInMemoryDatabase && string.IsNullOrWhiteSpace(databaseConfig.ConnectionString))
            {
                throw new InvalidOperationException("Database connection string is not configured properly.");
            }*/

            if (databaseConfig.UseInMemoryDatabase)
            {
                services.AddDbContext<DataBaseContext>(options =>
                    options.UseInMemoryDatabase("ParkingDatabase"));
            }
            else
            {
                services.AddDbContext<DataBaseContext>(options =>
                    options.UseNpgsql(databaseConfig.ConnectionString,
                        npgsqlOptions => npgsqlOptions.MigrationsAssembly(
                            typeof(DataBaseContext).Assembly.FullName)));
            }
        }

        private static void AddIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataBaseContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });
        }
    }

    public class DatabaseConfiguration
    {
        public bool UseInMemoryDatabase { get; set; }
        public string ConnectionString { get; set; }
    }
}
