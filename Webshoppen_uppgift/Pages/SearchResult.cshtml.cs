using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    public class SearchResultModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public string SearchWord { get; set; }
        public List<ProductItem> Products { get; set; }

        public SearchResultModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public class ProductItem
        {
            public int Price { get; set; }
            public string Name { get; set; }

            public string Desc { get; set; }

            public int Quantity { get; set; }

        }

        public void OnGet(string searchquery)
        {
            SearchWord = searchquery;

            var products = from p in _dbContext.Products select p;

            if (!String.IsNullOrEmpty(SearchWord))
            {
                products = products.Where(s => s.Name.Contains(SearchWord));
            }

            Products = new List<ProductItem>();
            foreach (var product in products)
            {
                Products.Add(new ProductItem { Name = product.Name, Price = product.Price, Desc = product.Description, Quantity = product.Quantity });
            }
        }
    }
}
