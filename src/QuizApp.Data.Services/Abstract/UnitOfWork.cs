using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Core.Interfaces;
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizApp.Data.Services.Abstract
{
	public abstract class UnitOfWork: IUnitOfWork
	{
		private readonly DbContext _context = null;
		//private readonly ILogger _log;
		
		public UnitOfWork(DbContext context) //, ILog log)
		{
			_context = context;
			//_log = log;
		}

		public virtual bool Save()
		{
			try
			{
				_context.SaveChanges();
			}
			catch (ValidationException e)
			{
				StringBuilder outputLines = new StringBuilder();
				outputLines.AppendFormat("Validation Error: {0}", e.Message);
				if (e.Data.Count > 0)
				{
					outputLines.AppendLine("Additional Information");
					foreach (DictionaryEntry eve in e.Data)
					{ 
						outputLines.AppendFormat("{0}: Key: \"{0}\", Value: \"{1}\"", DateTime.Now, eve.Key, eve.Value);
					}
				}
				//_log.Info(outputLines.ToString());
				throw;
			}
			catch (Exception ex)
			{
				StringBuilder outputLines = new StringBuilder();
				outputLines.Append(ex.Message);
				//_log.Info(outputLines.ToString());
				throw;
			}
			return true;
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
					_context.Dispose();
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
