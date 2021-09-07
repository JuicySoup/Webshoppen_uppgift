using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Webshoppen_uppgift.Data;

namespace Webshoppen_uppgift.Pages
{
    [BindProperties]
    [Authorize(Roles = "Admin, Manager")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public void OnGet(int id)
        {
            Id = id;
            var product = _dbContext.Products.First(p => p.Id == Id);
            Name = product.Name;
            Desc = product.Description;
            Price = product.Price;
            Quantity = product.Quantity;

        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid) return Page();
            var product = _dbContext.Products.First(p => p.Id == Id);
            product.Name = Name;
            product.Description = Desc;
            product.Price = Price;
            product.Quantity = Quantity;
            _dbContext.SaveChanges();
            return RedirectToPage("./ManageProducts");
        }
    }
}
