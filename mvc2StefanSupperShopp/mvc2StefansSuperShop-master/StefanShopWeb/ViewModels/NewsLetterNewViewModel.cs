using System;
using System.ComponentModel.DataAnnotations;

namespace StefanShopWeb.ViewModels
{
    public class NewsLetterNewViewModel
    {
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }
        public Guid Id { get; set; }

    }
}