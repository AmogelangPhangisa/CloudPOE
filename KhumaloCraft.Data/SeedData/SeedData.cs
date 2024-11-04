using KhumaloCraft.Data.Data;
using KhumaloCraft.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class SeedData
{
  public static async Task Initialize(IServiceProvider serviceProvider)
  {
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

    // Apply migrations
    await context.Database.MigrateAsync();

    // Seed Roles
    string[] roleNames = { "Admin", "User", "Manager" };
    foreach (var roleName in roleNames)
    {
      var roleExist = await roleManager.RoleExistsAsync(roleName);
      if (!roleExist)
      {
        await roleManager.CreateAsync(new IdentityRole(roleName));
      }
    }

    // Seed Admin User
    var adminUser = new User { UserName = "admin", Email = "admin@example.com", FirstName = "Super", LastName = "Admin" };
    var userExist = await userManager.FindByEmailAsync(adminUser.Email);
    if (userExist == null)
    {
      var createAdminUser = await userManager.CreateAsync(adminUser, "AdminPassword123!");
      if (createAdminUser.Succeeded)
      {
        await userManager.AddToRoleAsync(adminUser, "Admin");
      }
    }
  }
}
