using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        public IActionResult Index(string q)
        {
            var viewModel = new NewsLetterIndexViewModel();

            viewModel.NewsLetter = dbContext.NewsLetters
                .Where(r => q == null || r.Title.Contains(q))
                .Select(dbNewsLetter => new NewsLetterViewModel()
                {
                    Id = dbNewsLetter.Id,
                    Title = dbNewsLetter.Title,
                    Content = dbNewsLetter.Content
                }).ToList();
            return View(viewModel);
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

        [Authorize(Roles = "Admin, Product Manager")]
        public IActionResult Edit(string title)
        {
            var viewModel = new NewsLetterEditViewModel();

            var dbNewsLetter = dbContext.NewsLetters.Include(r => r.Title).First(r => r.Title == title);


            viewModel.Id = dbNewsLetter.Id;
            viewModel.Title = dbNewsLetter.Title;
            viewModel.Content = dbNewsLetter.Content;


            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Product Manager")]
        [HttpPost]
        public IActionResult Edit(Guid Id, NewsLetterEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbNewsLetter = dbContext.NewsLetters.Include(p => p.Id).First(r => r.Id == Id);

                dbNewsLetter.Title = viewModel.Title;
                dbNewsLetter.Content = viewModel.Content;
                dbNewsLetter.Id = viewModel.Id;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        //hejhej
    }

}