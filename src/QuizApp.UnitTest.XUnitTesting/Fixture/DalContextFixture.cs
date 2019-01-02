using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Dal;
using QuizApp.Data.Services.UnitOfWork;
using QuizApp.UnitTest.XUnitTesting.Static;
using System;

namespace QuizApp.UnitTest.XUnitTesting.Fixture
{
	public class DalContextFixture:IDisposable
	{
		private readonly SqliteConnection _connection;
		private QuizAppUnitOfWork _quizAppUnitOfWork;

		
		public DalContextFixture()
		{
			// In-memory database only exists while the connection is open
			_connection = new SqliteConnection("DataSource=:memory:");
			_quizAppUnitOfWork = null;
		}

		public QuizAppUnitOfWork CreateUnitOfWork(bool setSeed = true)
		{
			var context = CreateContext();
			_quizAppUnitOfWork = new QuizAppUnitOfWork(context);
			if (setSeed)
			{
				SeedHelper.SeedQuestionsAndAnswers(_quizAppUnitOfWork);
			}
			
			return _quizAppUnitOfWork;
		}

		private DalContext CreateContext()
		{
			if (_connection != null)
			{
				_connection.Open();
				DbContextOptions<DalContext> options = CreateOptions();
				using (var context = new DalContext(options))
				{
					context.Database.EnsureCreated();
				}
				return new DalContext(options);
			}
			return null;

		}

		private DbContextOptions<DalContext> CreateOptions()
		{
			return new DbContextOptionsBuilder<DalContext>()
				.UseSqlite(_connection)
				.Options;
		}
		
		
		#region Implementing IDiosposable...

		#region private dispose variable declaration...
		private bool _disposed = false;
		#endregion
		/// <summary>
		/// Protected Virtual Dispose method
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					if (_quizAppUnitOfWork != null)
					{
						_quizAppUnitOfWork.Dispose();
					}
					_connection.Close();
					_connection.Dispose();
				}
			}
			_disposed = true;
		}

		/// <summary>
		/// Dispose method
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
