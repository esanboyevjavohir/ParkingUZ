using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingUZ.Core.Common;
using ParkingUZ.Core.Entities;
using ParkingUZ.DataAccess.Identity;
using ParkingUZ.Shared.Services;
using System.Reflection;

namespace ParkingUZ.DataAccess.Persistence
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        private IClaimService? _claimService;

        public DataBaseContext(DbContextOptions<DataBaseContext> options, 
            IClaimService claimService)
            : base(options)
        {
            _claimService = claimService;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<User> User {  get; set; }
        public DbSet<Review> Reviews {  get; set; }
        public DbSet<Reservation> Reservations {  get; set; }
        public DbSet<QRCode> QRCodes {  get; set; }
        public DbSet<ParkingSubscription> ParkingSubscriptions {  get; set; }
        public DbSet<Payment> Payments {  get; set; }
        public DbSet<ParkingSpot> ParkingSpots {  get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans {  get; set; }
        public DbSet<ParkingZone> ParkingZones {  get; set; }
        public DbSet<Discount> Discounts {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            if(_claimService != null)
            {
                foreach(var entry in ChangeTracker.Entries<IAuditedEntity>())
                {
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedOn = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entry.Entity.UpdatedOn = DateTime.Now;
                            break;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
