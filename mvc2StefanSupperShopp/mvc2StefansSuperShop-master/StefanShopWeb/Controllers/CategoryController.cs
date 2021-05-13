using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StefanShopWeb.Data;
using StefanShopWeb.ViewModels;

namespace StefanShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index(string q)
        {
            var viewModel = new CategoryIndexViewModel();

            viewModel.Products = dbContext.Products
                .Include(r=> r.Category)
                .Where(r => q == null || r.CategoryId.ToString().Equals(q))
                .Select(categories => new CategoryIndexViewModel()
                {
                    CategoryName = categories.Category.CategoryName,
                    CategoryId= categories.Category.CategoryId,

                }).ToList();
            return View(viewModel);
        }
    }
}