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
            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();//identity class larýný contexte baðlamak için
            builder.Services.AddHttpClient();
            // Add services to the container.
            builder.Services.AddTransient<IValidator<CreateGuestDto>,CreateGuestValidator>();//Validation kontrolün yapmasý gereken yeri belirler.Bir tane örnek yazmak yeterli
			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation();//Razor cshtml tarafýnda deðiþiklik yapýldýðýnda tekrar projeyi kaldýrmadan görmeye yarar. Fluentvalidation þartlarý saðlayýp saðlamadýðýna bakar
            builder.Services.AddAutoMapper(typeof(Program));
			//UseAuthentication() bu metotun yetkilendirmeyi çalýþtýrmasý için altaki addmvc ve configureapplicationcookie metotlarýný çalýþtýrman gerek
			builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()//autohentice olmuþ kullanýcý zorunluluðu getirir
                .Build();//inþa eder
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.ConfigureApplicationCookie(options=>
            {
                options.Cookie.HttpOnly= true;//sadece http ye izin ver
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);//giriþ yapýlýnca kalýnacak süre
                options.LoginPath = "/Login/Index/";//açýlýþta ve süre sonunda açýlacak sayfa
            });
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code{0}");//Olmayan url e gidildiðinde yönledirme yapmak için kullanýlýr
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