using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    public class SearchResultModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public string SearchWord { get; set; }
        public string SortPrice { get; set; }
        public List<ProductItem> Products { get; set; } = new List<ProductItem>();

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

        public void OnGet(string searchquery, string sortOrder)
        {
            SearchWord = searchquery;
            SortPrice = sortOrder == "price" ? "price_desc" : "price";

            var products = from p in _dbContext.Products select p;
            if (!string.IsNullOrEmpty(SearchWord))
            {
                products = products.Where(s => s.Name.Contains(SearchWord));
                switch (sortOrder)
                {
                    case "price_desc":
                        products = products.OrderByDescending(product => product.Name);
                        break;
                    case "price":
                        products = products.OrderBy(product => product.Price);
                        break;
                    default:
                        products = products.OrderBy(product => product.Name);
                        break;
                }
                foreach (var product in products)
                {
                    Products.Add(new ProductItem { Name = product.Name, Price = product.Price, Desc = product.Description, Quantity = product.Quantity });
                }
            }


        }
    }
}
