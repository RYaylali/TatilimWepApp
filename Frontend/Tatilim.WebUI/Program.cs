using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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
			//UseAuthentication() bu metotun yetkilendirmeyi �al��t�rmas� i�in altaki addmvc ve configureapplicationcookie metotlar�n� �al��t�rman gerek
			builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()//autohentice olmu� kullan�c� zorunlulu�u getirir
                .Build();//in�a eder
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.ConfigureApplicationCookie(options=>
            {
                options.Cookie.HttpOnly= true;//sadece http ye izin ver
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);//giri� yap�l�nca kal�nacak s�re
                options.LoginPath = "/Login/Index/";//a��l��ta ve s�re sonunda a��lacak sayfa
            });
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code{0}");//Olmayan url e gidildi�inde y�nledirme yapmak i�in kullan�l�r
            app.UseHttpsRedirection();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();//yetklendirme yapar
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");

            app.Run();
        }
    }
}