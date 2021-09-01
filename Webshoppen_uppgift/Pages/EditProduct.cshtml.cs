using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    [BindProperties]
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public EditProductModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product is not null)
            {
                Name = product.Name;
                Desc = product.Description;
                Price = product.Price;
            }
            else
            {
                Name = "Product ID does not exist.";
            }

        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
                product.Name = Name;
                product.Description = Desc;
                product.Price = Price;
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
