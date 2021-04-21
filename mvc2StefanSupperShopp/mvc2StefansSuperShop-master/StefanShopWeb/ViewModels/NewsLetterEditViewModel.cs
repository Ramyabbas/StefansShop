using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StefanShopWeb.ViewModels
{
    public class NewsLetterEditViewModel
    {
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }
        public Guid Id { get; set; }
        public List<NewsLetterViewModel> NewsLetter { get; set; }
    }
}