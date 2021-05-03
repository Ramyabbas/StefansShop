using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StefanShopWeb.ViewModels
{
    public class NewsLetterSubscribe
    {
        public StatusCode StatusCode { get; set; }
        public string Email { get; set; }
    }
    public enum StatusCode
    {
        Unknown,
        AlreadySubscribed,
        SuccessSubscribed
    }

}

