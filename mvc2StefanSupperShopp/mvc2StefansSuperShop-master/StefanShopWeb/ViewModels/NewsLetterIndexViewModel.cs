using System;
using System.Collections.Generic;
using StefanShopWeb.Models;

namespace StefanShopWeb.ViewModels
{
    public class NewsLetterIndexViewModel
    {
        public string q { get; set; }
        public List<NewsLetterViewModel> NewsLetter { get; set; }

        public List<SentNewsLetter> SentNewsLetters { get; set; }


    }
}