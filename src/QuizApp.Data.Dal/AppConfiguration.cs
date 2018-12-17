using Microsoft.Extensions.Configuration;
using System.IO;

namespace QuizApp.Data.Dal
{

	public class AppConfiguration
	{
		//private readonly string _sample;

		public AppConfiguration()
		{
			var configurationBuilder = new ConfigurationBuilder();
			var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
			configurationBuilder.AddJsonFile(path, false);

			var root = configurationBuilder.Build();
			SqlDataConnection = root.GetConnectionString("DataConnection");

			//var appSetting = root.GetSection("ApplicationSettings");
			//var test = appSetting["Sample"];
		}

		public string SqlDataConnection { get; }

		//public string Sample
		//{
		//	get => _sample;
		//}
	}
}
