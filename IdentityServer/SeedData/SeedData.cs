using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.SeedData
{
    public static class SeedData
    {
        public static void EnsureSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            if (context != null)
            {
                EnsureSeedData(context);
            }

            // EnsureUsers(scope);
        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients.ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.IdentityResources.ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in Config.ApiScopes.ToList())
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.ApiResources.ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }

                context.SaveChanges();
            }
        }

        private static void EnsureUsers(IServiceScope scope)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var vachovia = userMgr.FindByNameAsync("vachovia").Result;
            if (vachovia == null)
            {
                vachovia = new IdentityUser
                {
                    UserName = "vachovia",
                    Email = "vachovia@email.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(vachovia, "P@ssword1").Result;

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(
                        vachovia, new Claim[]
                        {
                            new Claim(JwtClaimTypes.Name, "Vladislav Petrosyan"),
                            new Claim(JwtClaimTypes.GivenName, "Vladislav"),
                            new Claim(JwtClaimTypes.FamilyName, "Petrosyan"),
                            new Claim(JwtClaimTypes.WebSite, "https://vachovia.com"),
                            new Claim("Location", "Toronto")
                        }
                    ).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }
        }
    }
}
