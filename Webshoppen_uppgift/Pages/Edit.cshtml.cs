using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public Product Product { get; set; }

        public void OnGet(int id)
        {
            Product = _dbContext.Products.First(product => product.Id == id);
        }
        public IActionResult OnPost()
        {
            _dbContext.Products.Update(Product);
            _dbContext.SaveChanges();
            return RedirectToPage("./ManageProducts");
        }
    }
}
