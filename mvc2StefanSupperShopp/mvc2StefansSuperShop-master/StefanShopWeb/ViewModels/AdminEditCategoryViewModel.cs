using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace StefanShopWeb.ViewModels
{
    public class AdminEditCategoryViewModel
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public IFormFile NewPicture { get; set; }
        public int ImgVersion { get; set; }
    }
}
