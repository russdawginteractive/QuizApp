using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using QuizApp.Data.Dal;
using QuizApp.Data.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.Database
{
	public class FakeDbTesting
	{
		public FakeDbTesting()
		{
		}

		[Fact]
		public void TestSqlLiteDatabase()
		{
			// In-memory database only exists while the connection is open
			var connection = new SqliteConnection("DataSource=:memory:");
			connection.Open();
			bool created = false;
			IEnumerable<IdentityUser> users = null;
			string nonAdminUserEmail = null;
			string expectedEmail = "russell.griffith@gmail.com";
			int expectedCount = 2;
			var actualCount = 0;
			string lookupUserName = "russdawgbass";

			try
			{
				var options = new DbContextOptionsBuilder<DalContext>()
					.UseSqlite(connection)
					.Options;

				using (var context = new DalContext(options))
				{
					created = context.Database.EnsureCreated();
					
					using (var uow = new QuizAppUnitOfWork(context))
					{
						users = uow.UserReadOnlyRepository.GetAll();
						actualCount = users.Count();
						IdentityUser singleUser = users.FirstOrDefault(x => x.UserName == lookupUserName);
						if (singleUser != null)
						{
							nonAdminUserEmail = singleUser.Email;
						}
						

						
					}
				}
			}
			finally
			{
				connection.Close();
			}

			Assert.True(created);
			Assert.NotNull(users);
			Assert.Equal(expectedCount, actualCount);
			Assert.Equal(expectedEmail, nonAdminUserEmail);

		}

		[Fact]
		public void TestInMemoryDatabase()
		{
			IEnumerable<IdentityUser> users = null;
			var options = new DbContextOptionsBuilder<DalContext>()
					.UseInMemoryDatabase("test")
					.Options;

			using (var dalContext = new DalContext(options))
			{
				using (var uow = new QuizAppUnitOfWork(dalContext))
				{
					users = uow.UserReadOnlyRepository.GetAll();
				}
			}

			Assert.NotNull(users);
			Assert.True(users.Count() == 0);
		}
			
	}
}
