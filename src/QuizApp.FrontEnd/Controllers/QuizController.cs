using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuizApp.Data.Dal;
using QuizApp.Data.Entities.Models;
using Simple.OData.Client;

namespace QuizApp.FrontEnd.Controllers
{
    public class QuizController : Controller
    {
        private readonly DalContext _context;
		private readonly ODataClient _client;

        public QuizController(DalContext context, ODataClient client)
        {
            _context = context;
			_client = client;
		}

        //// GET: Quiz
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Quiz.ToListAsync());
        //}

		// GET: Quiz
		public IActionResult Index()
		{
			return View();
		}
		public async Task<ActionResult> Quiz_Read([DataSourceRequest] DataSourceRequest request)
		{

			var quizzes = await _client.For<Quiz>().FindEntriesAsync();
			return Json(quizzes.ToDataSourceResult(request)); //_context.Quiz.Select(s => new { s.Title, s.EventId, s.Active, s.PathToQuizReference }).ToDataSourceResultAsync(request));
		}

		[HttpPost]
		public async Task<ActionResult> Quiz_Create([DataSourceRequest] DataSourceRequest request, Quiz quiz)
		{

			Quiz returnQuiz = null; 
			if (quiz != null && ModelState.IsValid)
			{
				returnQuiz = await _client.For<Quiz>().Set(quiz).InsertEntryAsync(); //productService.Create(product);
			}

			return Json(new[] { returnQuiz }.ToDataSourceResult(request, ModelState));
			//throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<ActionResult> Quiz_Update([DataSourceRequest] DataSourceRequest request, Quiz quiz)
		{
			Quiz updateQuiz = quiz;
			if (quiz != null && ModelState.IsValid)
			{
				updateQuiz = await _client.For<Quiz>().Key(updateQuiz.Id).Set(quiz).UpdateEntryAsync();
			}
			return Json(new[] { updateQuiz }.ToDataSourceResult(request, ModelState));
		}

		[HttpPost]
		public async Task<ActionResult> Quiz_Destroy([DataSourceRequest] DataSourceRequest request, Quiz quiz)
		{

			if (quiz != null)
			{
				await _client.For<Quiz>().Key(quiz.Id).DeleteEntryAsync();
			}

			return Json(new[] { string.Empty }.ToDataSourceResult(request, ModelState));
		}

		// GET: Quiz/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // GET: Quiz/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quiz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,EventId,PathToQuizReference,Active,Id,Created,Modified")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quiz);
        }

        // GET: Quiz/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }
            return View(quiz);
        }

        // POST: Quiz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,EventId,PathToQuizReference,Active,Id,Created,Modified")] Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizExists(quiz.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quiz);
        }

        // GET: Quiz/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quiz = await _context.Quiz.FindAsync(id);
            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizExists(int id)
        {
            return _context.Quiz.Any(e => e.Id == id);
        }

		internal class ODataResponse<T>
		{
			public List<T> Value { get; set; }
		}
	}
}
