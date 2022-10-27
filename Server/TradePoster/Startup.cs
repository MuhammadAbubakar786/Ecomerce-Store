using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using TradePoster.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using TradePoster.Models.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.UI.Services;
using TradePoster.Utilities;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using TradePoster.Services.UserManagement;
using TradePoster.Services.HomePage;

namespace TradePoster
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			#region CORS_DEVELOPMENT
			services.AddCors(c =>
			{
				c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			});
			#endregion
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();
			//services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedEmail = false);

		services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddTransient<IEmailSender, EmailSender>();
			#region Services (Repository) Dependency Injection
			services.AddScoped<IUserManagerService, UserManagerService>();
			services.AddScoped<IHomePageService, HomePageService>();
            #endregion
            #region Get APP Settings Data
            services.Configure<AppSettings>(Configuration.GetSection("TradePosterSettings"));
            services.Configure<EmailConfigurationData>(Configuration.GetSection("MailSettings"));
			#endregion
			#region JSON NESTED CYCLE PREVENTER
			services.AddControllers().AddJsonOptions(x =>
			x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
			//services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

			#endregion
			#region Swagger			
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger  Documentation", Version = "v1" });

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please insert JWT with Bearer into field",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement {
			   {
				 new OpenApiSecurityScheme
				 {
				   Reference = new OpenApiReference
				   {
					 Type = ReferenceType.SecurityScheme,
					 Id = "Bearer"
				   }
				  },
				  new string[] { }
				}
			});
				//c.IncludeXmlComments(Path.Combine(
				//         Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"{this.GetType().Assembly.GetName().Name}.xml"
				//     ));
				//c.CustomSchemaIds(x => x.FullName);
			});
			#endregion
			#region Validate the JWT Token 
			var appSetting = Configuration.GetSection("TradePosterSettings");
			var mySettings = appSetting.Get<AppSettings>();
			var key = Encoding.ASCII.GetBytes(mySettings.SecretKey);

			services.AddAuthentication(sharedOptions =>
			{
				sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				sharedOptions.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
				sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			   .AddJwtBearer(options =>
			   {
				   options.TokenValidationParameters = new TokenValidationParameters
				   {
					   IssuerSigningKey = new SymmetricSecurityKey(key),
					   ValidAudience = "Audience",
					   ValidIssuer = "Issuer",
					   ValidateIssuer = false,
					   ValidateAudience = false,
					   ValidateIssuerSigningKey = true,
					   ValidateLifetime = true,
					   ClockSkew = TimeSpan.FromMinutes(0)
				   };

				   //JWT Claims for SignalR Hub
				   //    options.Events = new JwtBearerEvents
				   //    {
				   //        OnMessageReceived = context =>
				   //        {
				   //            var accessToken = context.Request.Query["access_token"];

				   //            // If the request is for our hub...
				   //            var path = context.HttpContext.Request.Path;
				   //            if (!string.IsNullOrEmpty(accessToken) &&
				   //          (path.StartsWithSegments("/Hubs/MessageHub")))
				   //            {
				   //                // Read the token out of the query string
				   //                context.Token = accessToken;
				   //            }
				   //            return Task.CompletedTask;
				   //        }
				   //    };
			   });

			#endregion
			services.AddRazorPages();
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsProduction())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseCors(builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
			});
			#region Swagger
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.DefaultModelsExpandDepth(-1); // Hide the SCHEMAS
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Documentation V1");
			});
			#endregion
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
				  name: "areas",
				  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
			});
		}
	}
}
