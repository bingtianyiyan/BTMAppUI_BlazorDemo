using BTMAppUI.Data.Authentication;
using BTMAppUI.Service;
using DAL;
using DAL.Contracts;
using DAL.Models;
using Infrastructure.Repositories.AccountRepo;
using Infrastructure.Repositories.Base;
using Infrastructure.Repositories.ProductRepo;
using Infrastructure.Repositories.UploadImageRepo;
using Infrastructure.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace BTMAppUI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//// Add services to the container.
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();
			builder.Services.AddRazorPages();
			builder.Services.AddServerSideBlazor();
			builder.Services.AddScoped<ProtectedSessionStorage>();
			builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Shared");
			builder.Services.AddTransient<ISQLDataAccess, SQLDataAccess>();

			//SERVICES
			builder.Services.AddTransient<IProductService, ProductService>();
			builder.Services.AddTransient<IUserAccountService, UserAccountService>();
			builder.Services.AddTransient<IUploadImageService, UploadImageService>();

			//REPOSITORIES
			builder.Services.AddTransient<IProductRepository, ProductRepository>();
			builder.Services.AddTransient<IUploadImageRepository, UploadImageRepository>();
			builder.Services.AddTransient<IUserAccountRepository, UserAccountRepository>();


			builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Administrator"));
			});


			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.AccessDeniedPath = "/accessdenied";
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();
			app.MapBlazorHub();
			app.MapFallbackToPage("/_Host");

			app.Run();
		}
	}
}