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
            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();//identity class larýný contexte baðlamak için
            builder.Services.AddHttpClient();
            // Add services to the container.
            builder.Services.AddTransient<IValidator<CreateGuestDto>,CreateGuestValidator>();//Validation kontrolün yapmasý gereken yeri belirler.Bir tane örnek yazmak yeterli
			builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation();//Razor cshtml tarafýnda deðiþiklik yapýldýðýnda tekrar projeyi kaldýrmadan görmeye yarar. Fluentvalidation þartlarý saðlayýp saðlamadýðýna bakar
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