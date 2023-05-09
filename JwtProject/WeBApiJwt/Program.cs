using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WeBApiJwt
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
			{
				opt.RequireHttpsMetadata = false;
				opt.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidIssuer="http://localhost",//kimin tarafýndan karþýlýk bulacaðý
					ValidAudience= "http://localhost",//kim tarafýndan dinleneceðini gösterir
					IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi")),//kim hangi veriyi saðlarsa giriþ yapacaðý deðeri gösterir
					ValidateIssuerSigningKey=true,//signingkey çözümünü saðlar.Yukarýdaki aspnetcoreapiapi codunu çözer
					ValidateLifetime= true,//tokenin geçerlilik süresi token 5 dk geçerli örneðin
					ClockSkew=TimeSpan.Zero
				};
			});
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseRouting();
			app.UseAuthentication();//Yetkisi var mý
			app.UseAuthorization();//Süresi

			app.MapControllers();

			app.Run();
		}
	}
}