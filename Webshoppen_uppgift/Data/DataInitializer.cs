using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Webshoppen_uppgift.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            SeedProductCategories(dbContext);
            SeedProducts(dbContext);
            SeedRoles(dbContext);
            SeedUsers(userManager, dbContext);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager, ApplicationDbContext _dbContext)
        {
            if (userManager.FindByEmailAsync("contact@jonathanosterberg.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "contact@jonathanosterberg.com";
                user.Email = "contact@jonathanosterberg.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Test12345!").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();

            }
            if (userManager.FindByEmailAsync("jonteo97@gmail.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "jonteo97@gmail.com";
                user.Email = "jonteo97@gmail.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Test12345!").Result;
                userManager.AddToRoleAsync(user, "Manager").Wait();

            }
            _dbContext.SaveChanges();
        }

        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            if (!dbContext.Roles.Any(r => r.Name == "Admin"))
            {
                dbContext.Roles.Add(new IdentityRole {NormalizedName = "Admin", Name = "Admin"});
            }
            if (!dbContext.Roles.Any(r => r.Name == "Manager"))
            {
                dbContext.Roles.Add(new IdentityRole {NormalizedName = "Manager", Name = "Manager"});
            }

            dbContext.SaveChanges();
        }

        private static void SeedProduct(ApplicationDbContext dbContext, string name, string categ, string desc, int price, int quantity)
        {
            if (!dbContext.Products.Any(product => product.Name == name))
            {
                dbContext.ProductCategories.First(category => category.Name == categ).Products.Add(new Product
                {
                    Name = name,
                    Description = desc,
                    Price = price,
                    Quantity = quantity
                });
            }
        }

        private static void SeedCategory(ApplicationDbContext dbContext, string name)
        {
            if (!dbContext.ProductCategories.Any(category => category.Name == name))
            {
                dbContext.ProductCategories.Add(new ProductCategory()
                {
                    Name = name
                });
            }
        }

        public static void SeedProducts(ApplicationDbContext dbContext)
        {
            SeedProduct(dbContext, "Gtx 1080TI", "GPU", "Ett grafikkort från Nvidia år 2017", 5999, 10);

            SeedProduct(dbContext, "Gtx 2080TI", "GPU", "Ett highend grafikkort från Nvidia", 7899, 16);

            SeedProduct(dbContext, "Gtx 3080TI", "GPU", 
                "GPU-frekvens: 1440 MHz | GDDR6X | Rek. watt (dator): 750 W | Längd: 288.9 mm", 11999, 50);

            SeedProduct(dbContext, "MSI GeForce RTX 3060 Ti 8GB GAMING X LHR", "GPU",
                "GPU-frekvens: 1410 MHz | GDDR6 | Rek. watt (dator): 650 W | Längd: 235 mm", 7499, 50);

            SeedProduct(dbContext, "Logitech G915", "Tillbehör",
                "Highend wireless keyboard från Logitech", 1250, 50);

            SeedProduct(dbContext, "Logitech G Pro Gaming Keyboard", "Tillbehör",
                "Bakgrundsbelyst | Mekaniska brytare | USB | Vikt:Index1.cshtml 980 g", 1190, 50);

            SeedProduct(dbContext, "AMD Ryzen 5 5600X", "CPU",
                "Antal kärnor: 6 st | Antal trådar: 12 st | TDP: 65 W", 1250, 30);

            SeedProduct(dbContext, "AMD Ryzen 9 5900X", "CPU",
                "Antal kärnor: 12 st | Antal trådar: 24 st | TDP: 105 W", 1250, 5);

            SeedProduct(dbContext, "Lenovo IdeaPad 5 - 14 | Ryzen 7 | 16GB | 512GB", "Laptop",
                "Konstruerad för livet", 8990, 50);

            SeedProduct(dbContext, "Taurus Gaming RTX 3060 - 3600", "Datorer",
    "Gamingdator med RTX 3060", 15999, 50);

            dbContext.SaveChanges();
        }

        public static void SeedProductCategories(ApplicationDbContext dbContext)
        {
            SeedCategory(dbContext, "GPU");
            SeedCategory(dbContext, "CPU");
            SeedCategory(dbContext, "Laptop");
            SeedCategory(dbContext, "Datorer");
            SeedCategory(dbContext, "Tillbehör");
            dbContext.SaveChanges();
        }
    }
}
