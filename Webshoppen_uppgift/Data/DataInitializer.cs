using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Webshoppen_uppgift.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedProductCategories(dbContext);
            SeedProducts(dbContext);
        }

        public static void SeedProducts(ApplicationDbContext dbContext)
        {
            if (!dbContext.Products.Any(product => product.Name == "Gtx 1080TI"))
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Gtx 1080TI",
                    Description = "Ett grafikkort från Nvidia",
                    Pris = 5999,
                });

            }
            if (!dbContext.Products.Any(product => product.Name == "Logitech G915"))
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Logitech G915",
                    Description = "Highend tagentbord från Logitech",
                    Pris = 1299,
                });
            }
            dbContext.SaveChanges();
        }

        public static void SeedProductCategories(ApplicationDbContext dbContext)
        {
            if (!dbContext.ProductCategories.Any(category => category.Name == "GPU"))
            {
                dbContext.ProductCategories.Add(new ProductCategory()
                {
                    Name = "GPU"
                });

            }
            if (!dbContext.ProductCategories.Any(category => category.Name == "CPU"))
            {
                dbContext.ProductCategories.Add(new ProductCategory()
                {
                    Name = "CPU"
                });

            }
            if (!dbContext.ProductCategories.Any(category => category.Name == "Tangentbord"))
            {
                dbContext.ProductCategories.Add(new ProductCategory()
                {
                    Name = "Tangentbord"
                });
            }
            if (!dbContext.ProductCategories.Any(category => category.Name == "Mus"))
            {
                dbContext.ProductCategories.Add(new ProductCategory()
                {
                    Name = "Mus"
                });
            }
            dbContext.SaveChanges();
        }
    }
}
