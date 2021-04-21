using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StefanShopWeb.Data;
using StefanShopWeb.Models;
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

        [Authorize(Roles = "Admin, Product Manager")]
        public IActionResult New()
        {
            var viewModel = new NewsLetterNewViewModel();


            return View(viewModel);
        }


        [Authorize(Roles = "Admin, Product Manager")]
        [HttpPost]

        public IActionResult New(NewsLetterNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbNewsLetter = new NewsLetter();
                dbContext.NewsLetters.Add(dbNewsLetter);


                dbNewsLetter.Title = viewModel.Title;
                dbNewsLetter.Content = viewModel.Content;
                dbNewsLetter.Id = viewModel.Id;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}