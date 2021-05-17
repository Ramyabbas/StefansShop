using System;
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
            var viewModel = new AdminCategoryListViewModel();

            viewModel.Categories = dbContext.Categories
                .Where(r => q == null || r.CategoryName.Equals(q))
                .Select(categories => new AdminCategoryListViewModel.Category()
                {
                    Name = categories.CategoryName,
                    Id= categories.CategoryId,

                }).ToList();
            return View(viewModel);
        }

        public IActionResult CategoryProducts([FromRoute] int id, string q, string sortField, string sortOrder, int page = 1)
        {
            var query = dbContext.Products
                .Where(r => q == null || r.ProductName.Contains(q) || r.UnitPrice.ToString().Contains(q));

            var viewModel = new AdminCategoryListViewModel();

            viewModel.Products = dbContext.Products
                .Where(r => r.Category.CategoryId == id)
                .Select(dbProduct => new AdminProductListViewModel.Product()
                {
                    Id = dbProduct.ProductId,
                    Name = dbProduct.ProductName,
                    Price = dbProduct.UnitPrice
                }).ToList();
            //ANTAL POSTER SOM MATCHAR FILTRET
            int totalRowCount = query.Count();

            if (string.IsNullOrEmpty(sortField))
                sortField = "ProductName";
            if (string.IsNullOrEmpty(sortOrder))
                sortOrder = "asc";

            if (sortField == "ProductName")
            {
                if (sortOrder == "asc")
                    query = query.OrderBy(y => y.ProductName);
                else
                    query = query.OrderByDescending(y => y.ProductName);
            }

            if (sortField == "UnitPrice")
            {

                if (sortOrder == "asc")
                    query = query.OrderBy(y => y.UnitPrice);
                else
                    query = query.OrderByDescending(y => y.UnitPrice);
            }

            int pageSize = 20;
            var pageCount = (double)totalRowCount / pageSize;
            viewModel.TotalPages = (int)Math.Ceiling(pageCount);

            int howManyRecordsToSkip = (page - 1) * pageSize;

            query = query.Skip(howManyRecordsToSkip).Take(pageSize);
            
            
            viewModel.q = q;
            viewModel.SortOrder = sortOrder;
            viewModel.SortField = sortField;
            viewModel.Page = page;
            viewModel.OppositeSortOrder = sortOrder == "asc" ? "desc" : "asc";

            return View(viewModel);
        }
    }
}