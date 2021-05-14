using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StefanShopWeb.Data;
using StefanShopWeb.ViewModels;
using StefanShopWeb.Models;

namespace StefanShopWeb.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Category(int id)
        {

            return View();
        }


        [Authorize(Roles = "Admin, Product Manager")]
        public IActionResult New()
        {
            var viewModel = new ProductNewViewModel();
            viewModel.cateories = GetAllCategories();
            viewModel.Suppliers = GetAllSuppliers();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(ProductNewViewModel viewModel)
        {
            var category = GetAllCategories();
            var suppliers = GetAllSuppliers();
            if (ModelState.IsValid)
            {
                var dbProduct = new Products();
                dbContext.Products.Add(dbProduct);
                dbProduct.ProductName = viewModel.ProductName;
                dbProduct.CategoryId = viewModel.CategoryId;
                dbProduct.SupplierId = viewModel.SupplierId;
                dbProduct.UnitPrice = viewModel.UnitPrice.Value;
                dbProduct.UnitsInStock = viewModel.UnitsInStock.Value;
                dbProduct.QuantityPerUnit = viewModel.QuantityPerUnit;
                dbProduct.ReorderLevel = viewModel.ReorderLevel.Value;
                dbProduct.UnitsOnOrder = viewModel.UnitsOnOrder;
                dbContext.SaveChanges();
                return RedirectToAction("Products", "Admin");
            }
            viewModel.cateories = GetAllCategories();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Product Manager")]
        public IActionResult Edit(int id)
        {
            var viewModel = new ProductNewViewModel();

            var dbproduct = dbContext.Products.First(r => r.ProductId == id);


            viewModel.ProductId = dbproduct.ProductId;
            viewModel.ProductName = dbproduct.ProductName;
            viewModel.UnitPrice = dbproduct.UnitPrice.Value;
            viewModel.UnitsInStock = dbproduct.UnitsInStock.Value;
            viewModel.cateories = GetAllCategories();
            viewModel.Suppliers = GetAllSuppliers();
            viewModel.ReorderLevel = dbproduct.ReorderLevel;
            viewModel.QuantityPerUnit = dbproduct.QuantityPerUnit;
            viewModel.UnitsOnOrder = dbproduct.UnitsOnOrder;

            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Product Manager")]
        [HttpPost]
        public IActionResult Edit(int Id, ProductNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbproduct = dbContext.Products.First(r => r.ProductId == Id);

                dbproduct.ProductName = viewModel.ProductName;
                dbproduct.UnitPrice = viewModel.UnitPrice.Value;
                dbproduct.UnitsInStock = viewModel.UnitsInStock;
                dbproduct.CategoryId = viewModel.CategoryId;
                dbproduct.SupplierId = viewModel.SupplierId;
                dbproduct.UnitsOnOrder = viewModel.UnitsOnOrder;
                dbproduct.QuantityPerUnit = viewModel.QuantityPerUnit;
                dbproduct.ReorderLevel = viewModel.ReorderLevel;
                dbContext.SaveChanges();
                return RedirectToAction("Products", "Admin");
            }
            viewModel.cateories = GetAllCategories();
            viewModel.Suppliers = GetAllSuppliers();

            return View(viewModel);
        }

        private List<SelectListItem> GetAllCategories()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "0", Text = "Var vänlig och välj en kategori..." });

            list.AddRange(dbContext.Categories.Select(r => new SelectListItem
            {
                Text = r.CategoryName,
                Value = r.CategoryId.ToString()
            }));
            return list;
        }

        private List<SelectListItem> GetAllSuppliers()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "0", Text = "Var vänlig och välj en supplier..." });

            list.AddRange(dbContext.Suppliers.Select(r => new SelectListItem
            {
                Text = r.CompanyName,
                Value = r.SupplierId.ToString()
            }));
            return list;
        }

    }
}