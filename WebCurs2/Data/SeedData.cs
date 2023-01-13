﻿using Microsoft.AspNetCore.Identity;

namespace WebCurs2.Data
{
    public class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider provider)
        {
            var roleMgr = provider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var roleName in RoleNames.AllRoles)
            {
                var role = roleMgr.FindByNameAsync(roleName).Result;

                if (role == null)
                {
                    var result = roleMgr.CreateAsync(new IdentityRole { Name = roleName }).Result;
                    if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
                }
            }

            var userMgr = provider.GetRequiredService<UserManager<IdentityUser>>();

            var adminResult = await userMgr.CreateAsync(DefaultUsers.Administrator, "zxc123QWE");
            var userResult = await userMgr.CreateAsync(DefaultUsers.User, "zxc123QWE");
            var moderatorResult = await userMgr.CreateAsync(DefaultUsers.Moderator, "zxc123QWE");

            if (adminResult.Succeeded || userResult.Succeeded || moderatorResult.Succeeded)
            {
                var adminUser = await userMgr.FindByEmailAsync(DefaultUsers.Administrator.Email);
                var commonUser = await userMgr.FindByEmailAsync(DefaultUsers.User.Email);
                var moderatorUser = await userMgr.FindByEmailAsync(DefaultUsers.Moderator.Email);

                await userMgr.AddToRoleAsync(adminUser, RoleNames.Administrator);
                await userMgr.AddToRoleAsync(commonUser, RoleNames.User);
                await userMgr.AddToRoleAsync(moderatorUser, RoleNames.Moderator);
            }
        }
    }

    public static class RoleNames
    {
        public const string Administrator = "Admin";
        public const string User = "User";
        public const string Moderator = "Moderator";

        public static IEnumerable<string> AllRoles
        {
            get
            {
                yield return Administrator;
                yield return User;
                yield return Moderator;
            }
        }
    }

    public static class DefaultUsers
    {
        public static readonly IdentityUser Administrator = new IdentityUser
        {
            Email = "Admin@test.com",
            EmailConfirmed = true,
            UserName = "Admin@test.com"
        };

        public static readonly IdentityUser Moderator = new IdentityUser
        {
            Email = "Moderator@test.com",
            EmailConfirmed = true,
            UserName = "Moderator@test.com",
        };

        public static readonly IdentityUser User = new IdentityUser
        {
            Email = "User@test.com",
            EmailConfirmed = true,
            UserName = "User@test.com"
        };

        public static IEnumerable<IdentityUser> AllUsers
        {
            get
            {
                yield return Administrator;
                yield return Moderator;
                yield return User;
            }
        }
    }


    public static class Navigations
    {

    }
}