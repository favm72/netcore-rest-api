using REAL.API.Authentication;
using REAL.Common;
using REAL.Data.generated;
using REAL.Logic;
using REAL.Logic.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace REAL.API
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
			services.AddCors();
			services.AddControllers();
			services.AddDbContext<MyContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Conn"));
			});
			services.AddSingleton<ICustomDbContextFactory<MyContext>, CustomDbContextFactory<MyContext>>();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "REAL", Version = "v1" });
			});

			MyConfig config = Configuration.GetSection("MyConfig").Get<MyConfig>();

			services.AddSingleton(config);
			services.AddAuthService(config.SecretKey);
			services.AddHttpContextAccessor();
			services.AddScoped<IUserResolverService, UserResolverService>();
			services.AddScoped<AccountLogic>();
			services.AddScoped<ProductLogic>();
			services.AddScoped<StoreLogic>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "REAL v1"));
			}

			app.UseCors(builder => builder
				.AllowAnyHeader()
				.AllowAnyMethod()
				.SetIsOriginAllowed(_ => true)
				.AllowCredentials()
			);

			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}
