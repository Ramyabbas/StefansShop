using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StefanShopWeb.Models;

namespace StefanShopWeb.ViewModels
{
    public class AdminCategoryListViewModel : AdminViewModel
    {
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public IFormFile NyBild { get; set; }
        }

        public List<Category> Categories { get; set; }
        public List<AdminProductListViewModel.Product> Products { get; set; }
        public int TotalPages { get; set; }
        public string q { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public int Page { get; set; }
        public string OppositeSortOrder { get; set; }
    }
}
