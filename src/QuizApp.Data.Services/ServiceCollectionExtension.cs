using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Data.Dal;
using QuizApp.Data.Services.EdmModel;

namespace QuizApp.Data.Services
{
	public static class IServiceCollectionExtension
	{
		public static IServiceCollection DataServicesStartup(this IServiceCollection services)
		{
			services.AddScoped<IdentityDbContext<IdentityUser>, DalContext>();
			services.AddTransient<UserManager<IdentityUser>>();
			services.AddTransient<EdmModelBuilder>();
			return services;
		}
	}
}
