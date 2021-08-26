﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        private static void SeedProduct(ApplicationDbContext dbContext, string name, string categ, string desc, int price)
        {
            if (!dbContext.Products.Any(product => product.Name == name))
            {
                dbContext.ProductCategories.First(category => category.Name == categ).Products.Add(new Product
                {
                    Name = name,
                    Description = desc,
                    Price = price,
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
            SeedProduct(dbContext, "Gtx 1080TI", "GPU", "Ett grafikkort från Nvidia år 2017", 5999);

            SeedProduct(dbContext, "Gtx 2080TI", "GPU", "Ett highend grafikkort från Nvidia", 7899);

            SeedProduct(dbContext, "Gtx 3080TI", "GPU", 
                "GPU-frekvens: 1440 MHz | GDDR6X | Rek. watt (dator): 750 W | Längd: 288.9 mm", 11999);

            SeedProduct(dbContext, "MSI GeForce RTX 3060 Ti 8GB GAMING X LHR", "GPU",
                "GPU-frekvens: 1410 MHz | GDDR6 | Rek. watt (dator): 650 W | Längd: 235 mm", 7499);

            SeedProduct(dbContext, "Logitech G915", "Keyboard",
                "Highend wireless keyboard från Logitech", 1250);

            SeedProduct(dbContext, "Logitech G Pro Gaming Keyboard", "Keyboard",
                "Bakgrundsbelyst | Mekaniska brytare | USB | Vikt: 980 g", 1190);

            SeedProduct(dbContext, "AMD Ryzen 5 5600X", "CPU",
                "Antal kärnor: 6 st | Antal trådar: 12 st | TDP: 65 W", 1250);

            SeedProduct(dbContext, "AMD Ryzen 9 5900X", "CPU",
                "Antal kärnor: 12 st | Antal trådar: 24 st | TDP: 105 W", 1250);

            dbContext.SaveChanges();
        }

        public static void SeedProductCategories(ApplicationDbContext dbContext)
        {
            SeedCategory(dbContext, "GPU");
            SeedCategory(dbContext, "CPU");
            SeedCategory(dbContext, "Keyboard");
            SeedCategory(dbContext, "Mouse");
            dbContext.SaveChanges();
        }
    }
}
