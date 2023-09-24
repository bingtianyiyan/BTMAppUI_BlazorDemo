using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTMAppUI.Data.Models
{
    public class ProductModel
    {
        public int Product_Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Product Name is too long.")]
        [MinLength(5, ErrorMessage = "Product Name is too short.")]
        public string? Product_Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? QuantityPerUnit { get; set; }
        public int Category_id { get; set; }
        public int Subcategory_id { get; set; }

    }
}
