using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Core.Common;
using QuizApp.Data.Dal.Models;

namespace QuizApp.Data.Services.UnitOfWork
{
	public class QuizAppUnitOfWork : Abstract.UnitOfWork
	{
		private readonly DbContext _context;
		private CrudRepository<Quiz> _quizRepository;
		private CrudRepository<Question> _questionRepository;
		private CrudRepository<Answer> _answerRepository;
		private CrudRepository<QuizResult> _quizResultRepository;
		private ReadOnlyRepository<IdentityUser> _userReadOnlyRepository;

		public QuizAppUnitOfWork(DbContext context):base(context)
		{
			_context = context;
		}
		public CrudRepository<Quiz> QuizRepository {
			get
			{
				if (_quizRepository == null)
				{
					_quizRepository = new CrudRepository<Quiz>(_context);
				}
				return _quizRepository;
			}
		}
		public CrudRepository<Question> QuestionRepository
		{
			get
			{
				if (_questionRepository == null)
				{
					_questionRepository = new CrudRepository<Question>(_context);
				}
				return _questionRepository;
			}
		}
		public CrudRepository<Answer> AnswerRepository
		{
			get
			{
				if (_answerRepository == null)
				{
					_answerRepository = new CrudRepository<Answer>(_context);
				}
				return _answerRepository;
			}
		}
		public CrudRepository<QuizResult> QuizResultRepository
		{
			get
			{
				if (_quizResultRepository == null)
				{
					_quizResultRepository = new CrudRepository<QuizResult>(_context);
				}
				return _quizResultRepository;
			}
		}
		public ReadOnlyRepository<IdentityUser> UserReadOnlyRepository
		{
			get
			{
				if (_userReadOnlyRepository == null)
				{
					_userReadOnlyRepository = new CrudRepository<IdentityUser>(_context);
				}
				return _userReadOnlyRepository;
			}
		}
	}
}
