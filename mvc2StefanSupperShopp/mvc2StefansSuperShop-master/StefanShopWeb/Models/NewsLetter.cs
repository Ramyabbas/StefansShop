using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StefanShopWeb.Models
{
    [Table("NewsLetters")]
    public class NewsLetter
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsSent { get; set; }
    }
}