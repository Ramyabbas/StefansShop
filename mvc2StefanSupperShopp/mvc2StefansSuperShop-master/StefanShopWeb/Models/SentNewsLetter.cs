using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StefanShopWeb.Models
{
    [Table("SentNewsLetter")]
    public class SentNewsLetter
    {
        [Key] 
        [Required] 
        public int Id { get; set; }

        [Column("NewsLetterSubscriber")]
        public NewsLetterSubscriber Email { get; set; }

        [Column("NewsLetter")]
        public NewsLetter NewsLetter { get; set; }
      
        


    }
}