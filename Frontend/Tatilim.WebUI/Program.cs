using FluentValidation;
using FluentValidation.AspNetCore;
using Tatilim.DataAccessLayer.Concrete;
using Tatilim.EntityLayer.Concrete;
using Tatilim.WebUI.Dtos.GuestDto;
using Tatilim.WebUI.ValidationRules.GuestValidationRules;

namespace Tatilim.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();//identity class lar�n� contexte ba�lamak i�in
            builder.Services.AddHttpClient();
            // Add services to the container.
            builder.Services.AddTransient<IValidator<CreateGuestDto>,CreateGuestValidator>();//Validation kontrol�n yapmas� gereken yeri belirler.Bir tane �rnek yazmak yeterli
			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation();//Razor cshtml taraf�nda de�i�iklik yap�ld���nda tekrar projeyi kald�rmadan g�rmeye yarar. Fluentvalidation �artlar� sa�lay�p sa�lamad���na bakar
            builder.Services.AddAutoMapper(typeof(Program));
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}