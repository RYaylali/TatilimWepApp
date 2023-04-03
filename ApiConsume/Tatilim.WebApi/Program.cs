using Tatilim.BusinessLayer.Abstract;
using Tatilim.BusinessLayer.Concrete;
using Tatilim.DataAccessLayer.Abstract;
using Tatilim.DataAccessLayer.Concrete;
using Tatilim.DataAccessLayer.EntityFramework;

namespace Tatilim.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context>();
            builder.Services.AddScoped<IStaffDal, EfStaffDal>();
            builder.Services.AddScoped<IStaffService, StaffManager>();

            builder.Services.AddScoped<IServicesDal, EfServicesDal>();
            builder.Services.AddScoped<IServiceService, ServiceManager>();

            builder.Services.AddScoped<IRoomDal, EfRoomDal>();
            builder.Services.AddScoped<IRoomService, RoomManager>();

            builder.Services.AddScoped<ISubscribleDal, EfSubscribeDal>();
            builder.Services.AddScoped<ISubscribleService, SubscribleManager>();

            builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
            builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            builder.Services.AddScoped<IStaffDal, EfStaffDal>();
            builder.Services.AddScoped<IStaffService, StaffManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}