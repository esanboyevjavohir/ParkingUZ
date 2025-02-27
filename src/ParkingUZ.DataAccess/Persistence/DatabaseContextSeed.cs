﻿using Microsoft.AspNetCore.Identity;
using ParkingUZ.DataAccess.Identity;

namespace ParkingUZ.DataAccess.Persistence
{
    public class DatabaseContextSeed
    {
        public static async Task SeedDatabaseAsync(DataBaseContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser { UserName = "admin", Email = "admin@admin.com", EmailConfirmed = true };
                await userManager.CreateAsync(user, "Admin123.?");
            }
            await context.SaveChangesAsync();
        }
    }
}
