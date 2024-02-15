using BilgeCinema.MVC.Models;

namespace BilgeCinema.MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// appsettings.json kullan�m� i�in : 

			var settings = builder.Configuration.GetSection("Appsettings").Get<AppSettings>();

			builder.Services.AddHttpClient();// Client nesnesine api ye json fo�rmat�nda istek atmak i�in ihtiyac�m var 

			builder.Services.AddSingleton(settings);
			// addsingleton -> yukar�daki AppSetting class'�n� newlenip olu�turdu�u nesneden tek bir kopya olacak ve hep ayn� kopya (instance) kullan�lacak.

			// addscoped -> Her sitek yeni kopya.

			// burada neden addSingleton kullan�yoruz da AddScopped kullanm�yoruz? 
			// Belge almak i�in gerekli soru - Cevab� ��ren 




			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Movie}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
