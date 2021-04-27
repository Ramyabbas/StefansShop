using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StefanShopWeb.ViewModels
{
    public class NewsLetterViewModel
    {
        public List<NewsLetterViewModel> Email { get; set; }
        public Guid Id { get; set; }
        public List<NewsLetterViewModel> NewsLetter { get; set; } = new List<NewsLetterViewModel>();

        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }
        public bool IsSent { get; set; }
    }
}