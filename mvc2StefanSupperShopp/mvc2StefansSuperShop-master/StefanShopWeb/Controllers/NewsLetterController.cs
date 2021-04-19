using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StefanShopWeb.Data;
using StefanShopWeb.ViewModels;

namespace StefanShopWeb.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public NewsLetterController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index(Guid id)
        {
            var model = new NewsLetterViewModel();
            model.Email = dbContext.NewsLetterSubscribers
                .Where(r => r.Id == id)
                .Select(dbSubscriber => new NewsLetterViewModel()
                {
                    Id = dbSubscriber.Id
                }).ToList();

            return View(model);
        }
    }

}