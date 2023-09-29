using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Product
    {
        public Product()
        {
            QuantityPerUnit = 1;
            Category_id = 1;
            Subcategory_id = 1;
            Date_Modified = DateTime.Now;
        }
        [Key]
        public int Product_Id { get; set; }
        public string? Product_Name { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; }
        public DateTime? Date_Added { get; set; }
        public DateTime? Date_Modified { get; set; }
        public string? Description { get; set; }
        public int? QuantityPerUnit { get; set; }
        public DateTime? Date_Removed { get; set; }
        public int Category_id { get; set; }
        public int Subcategory_id { get; set; }
		//[ForeignKey("Product_Id")]
		//public virtual IEnumerable<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
		//[ForeignKey("Category_id")]
		//public virtual Category Category { get; set; }
		//[ForeignKey("Subcategory_id")]
		//public virtual Subcategory Subcategory { get; set; }
		public virtual IEnumerable<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public string PrimaryImage { get; set; }
	}
}
