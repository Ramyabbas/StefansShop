using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StefanShopWeb.ViewModels
{
    public class ProductNewViewModel
    {
        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Var vänlig och skriv in namnet")]
        [StringLength(40)]
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public List<SelectListItem> cateories { get; set; }
        public List<SelectListItem> Suppliers { get; set; }

    }
}
