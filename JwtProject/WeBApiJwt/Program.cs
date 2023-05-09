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
					ValidIssuer="http://localhost",//kimin taraf�ndan kar��l�k bulaca��
					ValidAudience= "http://localhost",//kim taraf�ndan dinlenece�ini g�sterir
					IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi")),//kim hangi veriyi sa�larsa giri� yapaca�� de�eri g�sterir
					ValidateIssuerSigningKey=true,//signingkey ��z�m�n� sa�lar.Yukar�daki aspnetcoreapiapi codunu ��zer
					ValidateLifetime= true,//tokenin ge�erlilik s�resi token 5 dk ge�erli �rne�in
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
			app.UseAuthentication();//Yetkisi var m�
			app.UseAuthorization();//S�resi

			app.MapControllers();

			app.Run();
		}
	}
}