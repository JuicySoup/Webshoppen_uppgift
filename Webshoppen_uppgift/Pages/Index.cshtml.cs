using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public class CategoryItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public string Image { get; set; }

        }

        public List<CategoryItem> CategoryList { get; set; }
        public void OnGet()
        {
            CategoryList = new List<CategoryItem>();
            foreach (var category in _dbContext.ProductCategories)
            {
                CategoryList.Add(new CategoryItem { Name = category.Name , Id = category.Id});
            }
        }
    }
}
