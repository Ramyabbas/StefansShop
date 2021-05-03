using System;
using System.Linq;
using System.Threading.Tasks;
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
                    Content = dbNewsLetter.Content,
                    IsSent = dbNewsLetter.IsSent
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
                dbNewsLetter.IsSent = viewModel.IsSent;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Admin, Product Manager")]
        public IActionResult Edit(Guid id)
        {
            var viewModel = new NewsLetterEditViewModel();

            var dbNewsLetter = dbContext.NewsLetters.First(r => r.Id == id);


            viewModel.Id = dbNewsLetter.Id;
            viewModel.Title = dbNewsLetter.Title;
            viewModel.Content = dbNewsLetter.Content;
            viewModel.IsSent = dbNewsLetter.IsSent;


            return View(viewModel);
        }

        [Authorize(Roles = "Admin, Product Manager")]
        [HttpPost]
        public IActionResult Edit(NewsLetterEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbNewsLetter = dbContext.NewsLetters.First(r => r.Id == viewModel.Id);

                dbNewsLetter.Title = viewModel.Title;
                dbNewsLetter.Content = viewModel.Content;
                dbNewsLetter.Id = viewModel.Id;
                dbNewsLetter.IsSent = viewModel.IsSent;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            var subscriber = dbContext.NewsLetterSubscribers.FirstOrDefault(x => x.Email == email);
            var newsletterSubscribed = new NewsLetterSubscribe();
            if (subscriber != null)
            {
                newsletterSubscribed.StatusCode = ViewModels.StatusCode.AlreadySubscribed;
                return View(newsletterSubscribed);
            }

            newsletterSubscribed.StatusCode = ViewModels.StatusCode.SuccessSubscribed;
            var subcriber = new NewsLetterSubscriber();
            dbContext.NewsLetterSubscribers.Add(subcriber);
            subcriber.Email = email;
            
            await dbContext.SaveChangesAsync();
            return View(newsletterSubscribed);
        }
    }

}