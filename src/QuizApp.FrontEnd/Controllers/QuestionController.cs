using Microsoft.AspNetCore.Mvc;
using QuizApp.Data.Dal;
using QuizApp.Data.Entities.Models;
using QuizApp.Data.Entities.ViewModels;
using QuizApp.Middleware.Services.Interface;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.FrontEnd.Controllers
{
	public class QuestionController : Controller
	{
		private readonly DalContext _context;
		private readonly ODataClient _client;
		private readonly IQuestionService _service;
		public QuestionController(DalContext context, ODataClient client, IQuestionService service)
		{
			_context = context;
			_client = client;

		}
		
        public async Task<IActionResult> Index(int id)
        {
			Quiz quiz = await _client.For<Quiz>().Key(id).Expand(x => x.Questions).FindEntryAsync();
			ViewData["QuizId"] = id;
			return View(quiz.Questions);
        }

		// POST: Quiz/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(IEnumerable<QuestionViewModel> question)
		{
			if (question.Count() <= 0)
			{
				throw new NotImplementedException();
			}
			throw new NotImplementedException();
		}

	}
}