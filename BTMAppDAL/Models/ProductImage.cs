using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class ProductImage
    {

        public int Image_Id { get; set; }
        public byte[] Image { get; set; }
        public int Product_Id { get; set; }
        public string File_Name { get; set; }
        public string ConvertedProductImage 
        {
            get {
                string imreBase64Data = Convert.ToBase64String(Image);
                return string.Format("data:image/png;base64,{0}", imreBase64Data);
            }
            set { }
        }

	}
}