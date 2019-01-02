using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using QuizApp.Data.Dal;
using QuizApp.Data.Services;
using QuizApp.Data.Services.EdmModel;
using QuizApp.Data.Services.UnitOfWork;

namespace QuizApp.Api
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
			services.AddOData();
			services.AddTransient<QuizAppUnitOfWork>();
			services.AddTransient<DbContext, DalContext>();
			services.AddSingleton(Configuration);
			services.DataServicesStartup();

			services.AddDbContext<DalContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly("QuizApp.Data.Dal")));
			services.AddDefaultIdentity<IdentityUser>()
				.AddEntityFrameworkStores<DalContext>();
			
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(opt =>
				{
					opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
					opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				});
				
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, EdmModelBuilder modelBuilder)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			//app.UseMvc();
			app.UseMvc(routes =>
			{
				//routes.MapRoute(
				//	name: "default",
				//	template: "{controller=Home}/{action=Index}/{id?}");

				//routes.MapSpaFallbackRoute(
				//	name: "spa-fallback",
				//	defaults: new { controller = "Home", action = "Index" });
				app.UseMvc(routeBuilder =>
				{
					routeBuilder.MapODataServiceRoute("ODataRoutes", "odata", modelBuilder.GetEdmModel(app.ApplicationServices));
				});

			});
		}
	}
}
