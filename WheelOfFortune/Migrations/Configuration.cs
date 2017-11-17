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
            var coupons = context.Coupons.Count();

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

            var coupon1 = new Coupon
            {
                Id = 1,
                Code = "WUY57QM1N3",
                Value = cv1,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon2 = new Coupon
            {
                Id = 2,
                Code = "25D9O94QMR",
                Value = cv1,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon3 = new Coupon
            {
                Id = 3,
                Code = "LIHUU6JKA2",
                Value = cv1,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon4 = new Coupon
            {
                Id = 4,
                Code = "8TCRCEHHG0",
                Value = cv1,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon5 = new Coupon
            {
                Id = 5,
                Code = "U3A1OM7610",
                Value = cv1,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon6 = new Coupon
            {
                Id = 6,
                Code = "KBZ9TSYK1K",
                Value = cv2,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon7 = new Coupon
            {
                Id = 7,
                Code = "CPWI6JF5GO",
                Value = cv2,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon8 = new Coupon
            {
                Id = 8,
                Code = "VIKGA3OGPP",
                Value = cv2,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon9 = new Coupon
            {
                Id = 9,
                Code = "4APAKZUIO9",
                Value = cv2,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon10 = new Coupon
            {
                Id = 10,
                Code = "1ARMMXQPTR",
                Value = cv2,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon11 = new Coupon
            {
                Id = 11,
                Code = "RJQU9LDIXT",
                Value = cv3,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon12 = new Coupon
            {
                Id = 12,
                Code = "RMHFZAVGCM",
                Value = cv3,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon13 = new Coupon
            {
                Id = 13,
                Code = "Y4F4DKT9JS",
                Value = cv3,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon14 = new Coupon
            {
                Id = 14,
                Code = "OG7PVPSDNJ",
                Value = cv3,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon15 = new Coupon
            {
                Id = 15,
                Code = "WYT0HHQ2PE",
                Value = cv3,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon16 = new Coupon
            {
                Id = 16,
                Code = "UXLCMGB7K9",
                Value = cv4,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon17 = new Coupon
            {
                Id = 17,
                Code = "LGZ3DTP6MB",
                Value = cv4,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon18 = new Coupon
            {
                Id = 18,
                Code = "OJN851B8W5",
                Value = cv4,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon19 = new Coupon
            {
                Id = 19,
                Code = "A4QOWRKQJK",
                Value = cv4,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
            };

            var coupon20 = new Coupon
            {
                Id = 20,
                Code = "MQ4ETIIL6A",
                Value = cv4,
                DateCreated = new DateTime(2017, 11, 17, 10, 10, 10),
                DateExpired = new DateTime(2017, 11, 27, 10, 10, 10),
                DateExchanged = new DateTime(2017, 11, 17, 10, 10, 10),
                Active = true,
                User = adminUser
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

            if (coupons == 0)
            {
                context.Coupons.Add(coupon1);
                context.Coupons.Add(coupon2);
                context.Coupons.Add(coupon3);
                context.Coupons.Add(coupon4);
                context.Coupons.Add(coupon5);
                context.Coupons.Add(coupon6);
                context.Coupons.Add(coupon7);
                context.Coupons.Add(coupon8);
                context.Coupons.Add(coupon9);
                context.Coupons.Add(coupon10);
                context.Coupons.Add(coupon11);
                context.Coupons.Add(coupon12);
                context.Coupons.Add(coupon13);
                context.Coupons.Add(coupon14);
                context.Coupons.Add(coupon15);
                context.Coupons.Add(coupon16);
                context.Coupons.Add(coupon17);
                context.Coupons.Add(coupon18);
                context.Coupons.Add(coupon19);
                context.Coupons.Add(coupon20);
            }
        }
    }
}
