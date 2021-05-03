using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StefanShopWeb.Data;
using StefanShopWeb.Models;
using StefanShopWeb.ViewModels;

namespace StefanShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;

        }

        public async Task<IActionResult> Index()
        {
            var model = new StartPageModel();
            model.TrendingCategories = _context.Categories.Take(3).Select( c=> 
                        new StartPageModel.TrendingCategory { Id = c.CategoryId, Name = c.CategoryName }
                    ).ToList();

            ViewData["Shownewsletter"] = true;
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return View(model);

            var email = await _userManager.GetEmailAsync(user);
            if (string.IsNullOrEmpty(email))
                return View(model);

            var subscribed = _context.NewsLetterSubscribers.FirstOrDefault(x => x.Email == email);
            if (subscribed != null)
                ViewData["Shownewsletter"] = false;

            return View(model);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
