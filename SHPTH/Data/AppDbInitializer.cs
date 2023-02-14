using Microsoft.AspNetCore.Identity;
using SHPTH.Data.Static;
using SHPTH.Models;
using SHPTH.Models.Categories;
using System;

namespace SHPTH.Data
{
    public class AppDbInitializer
    {
        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {


        //        //Roles section
        //        var rolemanager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await rolemanager.RoleExistsAsync(UserRolesClass.Admin))
        //        {
        //            await rolemanager.CreateAsync(new IdentityRole(UserRolesClass.Admin));
        //        }
        //        if (!await rolemanager.RoleExistsAsync(UserRolesClass.User))    
        //        {
        //            await rolemanager.CreateAsync(new IdentityRole(UserRolesClass.User));
        //        }


        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Models.ApplicatonUser>>();
        //        string adminUserEmail = "admin@etickets.com";


        //        var adminuser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if(adminuser == null)
        //        {
        //            var newAdminUSer = new Models.ApplicatonUser()
        //            {
        //                Id = "1",
        //                FullName = "Daun Administrator",
        //                UserName = "Tvarina123-admin",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true

        //            };
        //            await userManager.CreateAsync(newAdminUSer, "123456");
        //            await userManager.AddToRoleAsync(newAdminUSer, UserRolesClass.Admin);
        //        }


        //        string UserEmail = "user@etickets.com";


        //        var user = await userManager.FindByEmailAsync(UserEmail);
        //        if (user == null)
        //        {
        //            var newUSer = new Models.ApplicatonUser()
        //            {
        //                Id = "2",

        //                FullName = "Daun Simple",
        //                UserName = "Clown-user",
        //                Email = UserEmail,
        //                EmailConfirmed = true

        //            };
        //            await userManager.CreateAsync(newUSer, "654321");
        //            await userManager.AddToRoleAsync(newUSer, UserRolesClass.User);
        //        }

        //    }


        //}

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SHPTHContext>();

                context.Database.EnsureCreated();


                if (!context.ClothSeparation.Any())
                {
                    context.ClothSeparation.AddRange(new List<Models.Categories.ClothSeparation>()
                {
                        new Models.Categories.ClothSeparation()
                        {
                           
                           Name = "Hoodies",
                           IsChecked = false

                        },
                        new Models.Categories.ClothSeparation()
                        {
                            
                           Name = "T-Shirts",
                           IsChecked = false

                        },
                        new Models.Categories.ClothSeparation()
                        {
                           
                           Name = "Trousers",
                           IsChecked = false

                        },
                        new Models.Categories.ClothSeparation()
                        {
                            
                           Name = "Shorts",
                           IsChecked = false

                        },
                        new Models.Categories.ClothSeparation()
                        {
                            
                           Name = "Shoes",
                           IsChecked = false

                        },


                });
                }

                context.SaveChanges();

                if (!context.SizeSeparations.Any())
                {
                    context.SizeSeparations.AddRange(new List<SizeSeparation>()
                    {
                        new SizeSeparation()
                        {
                            
                           Name = "S",
                           IsChecked = false

                        },
                        new SizeSeparation()
                        {
                            
                           Name = "M",
                           IsChecked = false

                        },
                        new SizeSeparation()
                        {
                             
                           Name = "L",
                           IsChecked = false

                        },
                        new SizeSeparation()
                        {
                           Name = "XL",
                           IsChecked = false

                        },
                        new SizeSeparation()
                        {
                              
                           Name = "XXL",
                           IsChecked = false

                        }
                    });
                }
                context.SaveChanges();
                //context.SaveChanges();
            }
        }








        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRolesClass.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRolesClass.Admin));
                if (!await roleManager.RoleExistsAsync(UserRolesClass.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRolesClass.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Models.ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Models.ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRolesClass.Admin);
                }



            }
        }

    }
}