using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using BTMAppUI;
using BTMAppUI.Shared;
using DAL;
using DAL.Contracts;
using DAL.Models;
using BTMAppUI.Data.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace BTMAppUI.Pages.Admin
{
	public partial class AddAndModifyProduct
	{
		private ProductModel product = new ProductModel();
		private ProductModel productUpdate;
		private List<Product> products;

		public string ReturnMessage { get; set; }
		public string SearchReturnMessage { get; set; }
		private string SearchKeyword { get; set; }
		protected override async Task OnInitializedAsync()
		{
			products = await productService.GetProducts();
		}

		private async Task AddNewProduct()
		{
			Product p = new Product
			{
				Product_Name = product.Product_Name,
				Price = product.Price
			};
			await productService.AddProduct(p);
			product = new ProductModel();
			products = await productService.GetProducts();
		}

		private async Task Delete_Click(int id)
		{
			await productService.Delete(id);
			Product product = products.Where(x => x.Product_Id == id).FirstOrDefault();
			products.Remove(product);


		}

		private async Task UpdateProduct_Click(ProductModel productUpdate)
		{
			Product p = new Product
			{
				Product_Name = productUpdate.Product_Name,
				Price = productUpdate.Price,
				Product_Id = productUpdate.Product_Id
			};
			ReturnMessage = await productService.Update(p);

			//refresh list
			if (string.IsNullOrEmpty(SearchKeyword))
				products = await productService.GetProducts();
			else
				SearchProducts(SearchKeyword);

		}
		private async Task SelectProduct_Click(int id)
		{
			ReturnMessage = string.Empty;
			Product productSelected = products.Where(x => x.Product_Id == id).FirstOrDefault();
			productUpdate = new ProductModel
			{
				Product_Name = productSelected.Product_Name,
				Price = productSelected.Price,
				Product_Id = productSelected.Product_Id
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
	}
}