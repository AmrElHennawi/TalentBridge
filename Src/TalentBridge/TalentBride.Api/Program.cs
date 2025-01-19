using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TalentBridge.Application.ExtentionMethods;
using TalentBridge.Application.Services;
using TalentBridge.Core.Settings;
using TalentBridge.DataContext;
using TalentBridge.Entities;

namespace TalentBride.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			var jwtSettings = builder.Configuration.GetSection("Jwt");
			builder.Services.Configure<JwtSettings>(jwtSettings);

			// Other services
			builder.Services.AddScoped<TokenService>();
			builder.Services.AddService();
			builder.Services.AddRepository();

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddIdentity<AppUser, IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});


			builder.Services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					var key = jwtSettings["SecretKey"];
					var secertKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
					options.TokenValidationParameters = new TokenValidationParameters
					{
						IssuerSigningKey = secertKey,
						ValidateIssuer = false,
						ValidateAudience = false,
					};
				});



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
