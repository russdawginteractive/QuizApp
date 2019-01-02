using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using QuizApp.Data.Entities.Models;
using System;

namespace QuizApp.Data.Services.EdmModel
{
	public class EdmModelBuilder
	{
		public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
		{
			var builder = new ODataConventionModelBuilder(serviceProvider);

			builder.EntitySet<Quiz>("Quiz")
				.EntityType
				.HasKey(e => e.Id)
				.Filter() // Allow for the $filter Command
				.Count() // Allow for the $count Command
				.Expand() // Allow for the $expand Command
				.OrderBy() // Allow for the $orderby Command
				.Page() // Allow for the $top and $skip Commands
				.Select(); // Allow for the $select Command; 

			builder.EntitySet<Question>("Question")
				.EntityType
				.HasKey(e => e.Id)
				.ContainsMany(e => e.Answers)
				.Filter() // Allow for the $filter Command
				.Count() // Allow for the $count Command
				.Expand() // Allow for the $expand Command
				.OrderBy() // Allow for the $orderby Command
				.Page() // Allow for the $top and $skip Commands
				.Select(); // Allow for the $select Command; 

			builder.EntitySet<Answer>("Answer")
				.EntityType
				.HasKey(e => e.Id)
				.Filter() // Allow for the $filter Command
				.Count() // Allow for the $count Command
				.Expand() // Allow for the $expand Command
				.OrderBy() // Allow for the $orderby Command
				.Page() // Allow for the $top and $skip Commands
				.Select(); // Allow for the $select Command; 

			builder.EntitySet<QuizResult>("QuizResult")
				.EntityType
				.HasKey(e => e.Id)
				.Filter() // Allow for the $filter Command
				.Count() // Allow for the $count Command
				.Expand() // Allow for the $expand Command
				.OrderBy() // Allow for the $orderby Command
				.Page() // Allow for the $top and $skip Commands
				.Select(); // Allow for the $select Command; 

			return builder.GetEdmModel();
		}
	}
}
