using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace QuizApp.Data.Dal
{
	public class ApiContextFactory : IDesignTimeDbContextFactory<DalContext>
	{
		public ApiContextFactory()
		{
		}


		public DalContext CreateDbContext(string[] args)
		{
			var config = new AppConfiguration();
			var builder = new DbContextOptionsBuilder<DalContext>();
			//builder.UseSqlServer(config.SqlDataConnection);
			builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuizDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
		
			return new DalContext(builder.Options);
		}
	}
}
