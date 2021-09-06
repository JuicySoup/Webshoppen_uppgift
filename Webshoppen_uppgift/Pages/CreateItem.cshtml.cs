using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    [BindProperties]
    public class CreateItemModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateItemModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public List<string> CategoryList { get; set; } = new List<string>
        {
            "GPU",
            "CPU",
            "Datorer",
            "Laptops",
            "Tillbeh�r"
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public string Category { get; set; }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _dbContext.ProductCategories.First(category => category.Name == Category).Products.Add(new Product
            {
                Name = Name,
                Description = Desc,
                Price = Price,
                Quantity = Quantity
            });
            _dbContext.SaveChanges();
            return RedirectToPage("/ManageProducts");
        }
    }
}

