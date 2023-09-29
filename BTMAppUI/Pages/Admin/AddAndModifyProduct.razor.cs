using Microsoft.AspNetCore.Components.Web;
using DAL.Models;
using BTMAppUI.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using FileInfo = DAL.Models.FileInfo;
using System.IO;

namespace BTMAppUI.Pages.Admin
{
	public partial class AddAndModifyProduct
	{
		private ProductModel product = new ProductModel();
		private ProductModel productUpdate;
		private List<Product> products;
		private ProductImage? productImage;
		private FileInfo? uploadedFile;

		public string ReturnMessage { get; set; }
		public string EditReturnMessage { get; set; }
		public string SearchReturnMessage { get; set; }
		private string SearchKeyword { get; set; }
		private byte[] imageData;

		protected override async Task OnInitializedAsync()
		{
			products = await productService.GetProducts();
		}

		private async Task AddNewProduct()
		{
			ReturnMessage = string.Empty;
			EditReturnMessage = string.Empty;
			Product p = new Product
			{
				Product_Name = product.Product_Name,
				Price = product.Price,
				Description = product.Description,
				Date_Added = DateTime.Now
			};
			int createdProductId = await productService.AddProduct(p);
			await UploadAttachedImage(createdProductId);

			product = new ProductModel();
			products = await productService.GetProducts();
		}

		private async Task UploadAttachedImage(int createdProductId)
		{
			//Upload image once product is created
			if (uploadedFile != null)
			{
				if (createdProductId > 0)
				{
					productImage = new ProductImage
					{
						File_Name = uploadedFile.Name,
						Image = uploadedFile.Content,
						Product_Id = createdProductId
					};

					await uploadImageService.UploadImageAsync(productImage);

					//refresh the list in memory
					products = await productService.GetProducts();
					SelectProduct(createdProductId);
				}
			}
		}

		private async Task Delete_Click(int id)
		{
			await productService.Delete(id);
			Product product = products.Where(x => x.Product_Id == id).FirstOrDefault();
			products.Remove(product);
			productUpdate = new ProductModel();
		}

		private async Task UpdateProduct_Click(ProductModel productUpdate)
		{
			Product p = new Product
			{
				Product_Name = productUpdate.Product_Name,
				Price = productUpdate.Price,
				Product_Id = productUpdate.Product_Id,
				Description = productUpdate.Description
			};
			EditReturnMessage = await productService.Update(p);
			await UploadAttachedImage(productUpdate.Product_Id);
			//refresh list
			if (string.IsNullOrEmpty(SearchKeyword))
				products = await productService.GetProducts();
			else
				await SearchProducts(SearchKeyword);

		}
		private async Task SelectProduct(int id)
		{
			ReturnMessage = string.Empty;
			EditReturnMessage = string.Empty;
			Product productSelected = products.Where(x => x.Product_Id == id).FirstOrDefault();
			ProductImage imageSelected = await uploadImageService.GetImage(productSelected.Product_Id); //add Getimage from service

			productUpdate = new ProductModel
			{
				Product_Name = productSelected.Product_Name,
				Price = Math.Round((decimal)productSelected.Price, 2),
				Product_Id = productSelected.Product_Id,
				Description = productSelected.Description,
				Product_Image = imageSelected?.ConvertedProductImage
			};
		}

		protected async Task SearchProducts(string keyword)
		{
			SearchReturnMessage = string.Empty;

			products = await productService.SearchProducts(keyword);
			if (!products.Any())
				SearchReturnMessage = "No results found.";

		}

		public void Enter(KeyboardEventArgs e)
		{
			if (e.Code == "Enter" || e.Code == "NumpadEnter")
			{
				return;
			}
		}

		private async Task OnInputFileChange(InputFileChangeEventArgs e)
		{
			var imageFile = e.File;

			using (var stream = imageFile.OpenReadStream())
			{
				using (var memoryStream = new MemoryStream())
				{
					await stream.CopyToAsync(memoryStream);
					imageData = memoryStream.ToArray();
				}
				uploadedFile = new FileInfo
				{
					Name = imageFile.Name,
					Content = imageData
				};
			}
		}
	}
}