using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    public class ManageProductsModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public ManageProductsModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProductItem> ProductsList { get; set; }
        public class ProductItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public string Desc { get; set; }
            public int Quantity { get; set; }
        }

        public void OnGet()
        {
            var products = from p in _dbContext.Products select p;

            ProductsList = new List<ProductItem>();

            foreach (var item in products)
            {
                ProductsList.Add(new ProductItem {Name = item.Name, Price = item.Price, Desc = item.Description, Quantity = item.Quantity , Id = item.Id});
            }
        }
    }
}
