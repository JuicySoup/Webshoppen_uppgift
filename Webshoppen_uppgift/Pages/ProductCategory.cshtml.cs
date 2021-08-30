using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    public class ProductCategoryModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoryModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public string CategoryName { get; set; }
        public List<ProductItem> ListOfProducts { get; set; }

        public class ProductItem
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Desc { get; set; }
        }

        public void OnGet(int categoryid)
        {
            var currentcategory = _dbContext.ProductCategories.Include(p => p.Products)
                .First(category => category.Id == categoryid);
            CategoryName = currentcategory.Name.ToUpper();

            ListOfProducts = currentcategory.Products.Select(product => new ProductItem{
                Name = product.Name,
                Price = product.Price,
                Desc = product.Description
            }).ToList();
        }
    }
}
