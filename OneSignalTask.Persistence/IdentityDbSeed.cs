using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace OneSignalTask.Persistence
{
    public class IdentityDbSeed
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IdentityDbSeed(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Seed()
        {
            SeedRoles();
            SeedUsers();
            SeedUsersRoles();
        }

        private void SeedRoles()
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "192d5f23-47e3-4a5b-8ce8-60e15e49043e",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "56c5d1e2-9d22-44a7-803f-f70833679215",
                    Name = "Readonly",
                    NormalizedName = "READONLY"
                }
            };

            foreach (var role in roles)
            {
                if (!_applicationDbContext.Roles.Any(r => r.Id == role.Id))
                {
                    _applicationDbContext.Roles.Add(role);
                }
            }

            _applicationDbContext.SaveChanges();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = "b6852d01-5936-47ac-9095-827d30f95c40",
                Email = "admin@test.com",
                UserName = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                NormalizedEmail = "ADMIN@TEST.COM",
                EmailConfirmed = true,
                SecurityStamp = String.Empty,
                PasswordHash = hasher.HashPassword(null, "admin")
            };

            var readonlyUser = new IdentityUser
            {
                Id = "b4d9f820-2be4-4fa6-996d-9fea476aac1c",
                Email = "readonly@test.com",
                UserName = "readonly@test.com",
                NormalizedUserName = "READONLY@TEST.COM",
                NormalizedEmail = "READONLY@TEST.COM",
                EmailConfirmed = true,
                SecurityStamp = String.Empty,
                PasswordHash = hasher.HashPassword(null, "readonly")
            };

            var users = new List<IdentityUser> { adminUser, readonlyUser };

            foreach (var user in users)
            {
                if(!_applicationDbContext.Users.Any(x => x.Id == user.Id))
                {
                    _applicationDbContext.Users.Add(user);
                }
            }

            _applicationDbContext.SaveChanges();
        }

        private void SeedUsersRoles()
        {
            var usersRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = "b6852d01-5936-47ac-9095-827d30f95c40",
                    RoleId = "192d5f23-47e3-4a5b-8ce8-60e15e49043e"
                },
                new IdentityUserRole<string>
                {
                    UserId = "b4d9f820-2be4-4fa6-996d-9fea476aac1c",
                    RoleId = "56c5d1e2-9d22-44a7-803f-f70833679215"
                }
            };

            foreach(var userRole in usersRoles)
            {
                if (!_applicationDbContext.UserRoles.Any(x => x.UserId == userRole.UserId && x.RoleId == userRole.RoleId))
                {
                    _applicationDbContext.UserRoles.Add(userRole);
                }
            }

            _applicationDbContext.SaveChanges();
        }
    }
}
