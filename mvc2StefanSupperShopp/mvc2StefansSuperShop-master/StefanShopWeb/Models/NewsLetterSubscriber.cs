using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefanShopWeb.Models
{
    [Table("NewsLetterSubscribers")]
    public class NewsLetterSubscriber
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public Guid Id { get; set; }
        public string Email { get; set; }


    }
}