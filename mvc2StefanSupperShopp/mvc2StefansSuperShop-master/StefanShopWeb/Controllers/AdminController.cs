using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using StefanShopWeb.Data;
using StefanShopWeb.ViewModels;

namespace StefanShopWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment _environment;

        public AdminController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {
            this.dbContext = dbContext;
            this._environment = environment;
        }
        List<MenuItem> SetupMenu(string activeAction)
        {
            var list = new List<MenuItem>();
            list.Add( new MenuItem { Text = "Products", Action = "Products", Controller="Admin", IsActive = activeAction == "Products"  } );
            list.Add(new MenuItem { Text = "Categories", Action = "Categories", Controller = "Admin", IsActive = activeAction == "Categories" });
            list.Add(new MenuItem { Text = "Newsletter", Action = "Index", Controller = "NewsLetter", IsActive = activeAction == "NewsLetter" });
            return list;
        }
        public IActionResult Index()
        {
            var model = new AdminViewModel();
            model.MenuItems = SetupMenu("");
            return View(model);
        }
        public IActionResult Products()
        {
            var model = new AdminProductListViewModel();
            model.MenuItems = SetupMenu("Products");
            model.Products = dbContext.Products.Include(p => p.Category).
                Select(p => new AdminProductListViewModel.Product {
                    Id = p.ProductId,
                    CategoryName = p.Category.CategoryName,
                    Name = p.ProductName,
                    Price = p.UnitPrice.Value
                }).ToList();
            return View(model);
        }

        public IActionResult EditProduct(int id)
        {
            var model = new AdminEditProductViewModel();
            model.MenuItems = SetupMenu("Products");
            var prod = dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            model.ProductId = prod.ProductId;
            model.ProductName = prod.ProductName;
            model.SupplierId = prod.SupplierId.Value;
            model.UnitPrice = prod.UnitPrice.Value;
            model.CategoryId = prod.CategoryId;
            model.Discontinued = prod.Discontinued;
            model.UnitsInStock = prod.UnitsInStock.Value;

            return View(model);
        }


        public IActionResult Categories()
        {
            var model = new AdminCategoryListViewModel();
            model.MenuItems = SetupMenu("Categories");
            model.Categories = dbContext.Categories.Select(c =>
                new AdminCategoryListViewModel.Category { Id = c.CategoryId, Name = c.CategoryName }).ToList();
            return View(model);
        }

        public IActionResult EditCategory(int id)
        {
            var viewModel = new AdminEditCategoryViewModel();

            var dbCategory = dbContext.Categories.FirstOrDefault(a => a.CategoryId == id);

            viewModel.CategoryId = dbCategory.CategoryId;
            viewModel.CategoryName = dbCategory.CategoryName;
            viewModel.Description = dbCategory.Description;


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditCategories(int id, AdminEditCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = dbContext.Categories.First(r => r.CategoryId == id);
                dbCategory.CategoryName = viewModel.CategoryName;
                dbCategory.Description = viewModel.Description;
                dbCategory.ImgVersion = dbCategory.ImgVersion + 1;
                dbContext.SaveChanges();
                string filename = dbCategory.CategoryId + "-" + dbCategory.ImgVersion + ".jpg";
                string totalPath = Path.Combine(_environment.WebRootPath,
                    "img", "Categories", filename);
                if (viewModel.NewPicture != null)
                {
                    using (var fileStream = new FileStream(totalPath, FileMode.Create))
                    {
                        viewModel.NewPicture.CopyTo(fileStream);
                    }

                }
                return RedirectToAction("Categories");
            }

            return View(viewModel);
        }

    }
}