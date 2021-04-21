using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
    }
}
