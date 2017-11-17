namespace WheelOfFortune.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WheelOfFortune.Models;
    using WheelOfFortune.Models.Domain;

    internal sealed class Configuration : DbMigrationsConfiguration<WheelOfFortune.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WheelOfFortune.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var wheelConfigs = context.WheelConfigurations.Count();
            var wheelSlices = context.WheelConfigurationSlices.Count();
            var couponValues = context.CouponValues.Count();

            var cv1 = new CouponValue
            {
                Id = 1,
                Value = 5
            };

            var cv2 = new CouponValue
            {
                Id = 2,
                Value = 10
            };

            var cv3 = new CouponValue
            {
                Id = 3,
                Value = 20
            };

            var cv4 = new CouponValue
            {
                Id = 4,
                Value = 50
            };

            var adminUser = new ApplicationUser
            {
                Id = "e31a3b70-3a1b-4276-b1fa-d1f4eccfca47",
                Active = true,
                Email = "admin@example.com",
                EmailConfirmed = true,
                PasswordHash = "AKmsfZCVv9M9CeftEEymCHGQy7T8tHTzrIXsH0jVEViPdx2ZQ9DMEA1DeIzC9Oj9/Q==", // 123456
                SecurityStamp = "c2e1b386-46fa-4410-a6d1-dff9a720c22e",
                UserName = "admin",
                UName = "admin",
                UserPhoto = new byte[10]
            };

            var wheelConfig1 = new WheelConfiguration
            {
                Id = 1,
                User = adminUser,
                DateCreated = DateTime.Now
            };

            var wheelConfig2 = new WheelConfiguration
            {
                Id = 2,
                DateCreated = DateTime.Now,
                User = adminUser
            };

            var slice1 = new WheelConfigurationSlice
            {
                Id = 1,
                Propability = 25,
                Win = true,
                Type = "string",
                Value = "Win x2",
                ResultText = "Yoo-hoo!",
                Score = 2,
                User = adminUser,
                WheelConfiguration = wheelConfig1
            };

            var slice2 = new WheelConfigurationSlice
            {
                Id = 2,
                Propability = 25,
                Win = true,
                Type = "string",
                Value = "Win x1.5",
                ResultText = "Yoo-hoo!",
                Score = 1.5,
                User = adminUser,
                WheelConfiguration = wheelConfig1
            };

            var slice3 = new WheelConfigurationSlice
            {
                Id = 3,
                Propability = 25,
                Win = true,
                Type = "string",
                Value = "Lose x2",
                ResultText = "Oops!",
                Score = -2,
                User = adminUser,
                WheelConfiguration = wheelConfig1
            };

            var slice4 = new WheelConfigurationSlice
            {
                Id = 4,
                Propability = 25,
                Win = true,
                Type = "string",
                Value = "Lose 1.5",
                ResultText = "Oops!",
                Score = -1.5,
                User = adminUser,
                WheelConfiguration = wheelConfig1
            };

            var slice5 = new WheelConfigurationSlice
            {
                Id = 5,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Win x2",
                ResultText = "Yoo-hoo!",
                Score = 2,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice6 = new WheelConfigurationSlice
            {
                Id = 6,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Win x1.5",
                ResultText = "Yoo-hoo!",
                Score = 1.5,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice7 = new WheelConfigurationSlice
            {
                Id = 7,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Lose x2",
                ResultText = "Oops!",
                Score = -2,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice8 = new WheelConfigurationSlice
            {
                Id = 8,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Lose 1.5",
                ResultText = "Oops!",
                Score = -1.5,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice9 = new WheelConfigurationSlice
            {
                Id = 9,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Lose 0.5",
                ResultText = "Oops!",
                Score = -0.5,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice10 = new WheelConfigurationSlice
            {
                Id = 10,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Lose 2.5",
                ResultText = "Oops!",
                Score = -2.5,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice11 = new WheelConfigurationSlice
            {
                Id = 11,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Win x2.5",
                ResultText = "Yoo-hoo!",
                Score = 2.5,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice12 = new WheelConfigurationSlice
            {
                Id = 12,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Win x0.5",
                ResultText = "Yoo-hoo!",
                Score = 0.5,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice13 = new WheelConfigurationSlice
            {
                Id = 13,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Lose x3",
                ResultText = "Oops!",
                Score = -3,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            var slice14 = new WheelConfigurationSlice
            {
                Id = 14,
                Propability = 10,
                Win = true,
                Type = "string",
                Value = "Win x4",
                ResultText = "Yoo-hoo!",
                Score = 4,
                User = adminUser,
                WheelConfiguration = wheelConfig2
            };

            if (!context.Users.Select(x => x.Id).Contains(adminUser.Id))
            {
                context.Users.Add(adminUser);

                context.Balances.Add(
                    new Balance {
                        Id = 1,
                        BalanceValue = 100,
                        User = adminUser
                    });

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    UserManager.AddToRole(adminUser.Id, "Admin");
                }
            }

            if (wheelConfigs == 0)
            {
                context.WheelConfigurations.Add(wheelConfig1);
                context.WheelConfigurations.Add(wheelConfig2);
            }

            if (wheelSlices == 0)
            {
                context.WheelConfigurationSlices.Add(slice1);
                context.WheelConfigurationSlices.Add(slice2);
                context.WheelConfigurationSlices.Add(slice3);
                context.WheelConfigurationSlices.Add(slice4);
                context.WheelConfigurationSlices.Add(slice5);
                context.WheelConfigurationSlices.Add(slice6);
                context.WheelConfigurationSlices.Add(slice7);
                context.WheelConfigurationSlices.Add(slice8);
                context.WheelConfigurationSlices.Add(slice9);
                context.WheelConfigurationSlices.Add(slice10);
                context.WheelConfigurationSlices.Add(slice11);
                context.WheelConfigurationSlices.Add(slice12);
                context.WheelConfigurationSlices.Add(slice13);
                context.WheelConfigurationSlices.Add(slice14);
            }

            if (couponValues == 0)
            {
                context.CouponValues.Add(cv1);
                context.CouponValues.Add(cv2);
                context.CouponValues.Add(cv3);
                context.CouponValues.Add(cv4);
            }
        }
    }
}
