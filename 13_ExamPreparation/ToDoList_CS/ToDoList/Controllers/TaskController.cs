using System;
using System.Linq;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
	public class TaskController : Controller
	{
	    [HttpGet]
        [Route("")]
	    public ActionResult Index()
	    {
			using (var db = new TodoListDbContext())
			{
				var tasks = db.Tasks.ToList();
				return View(tasks);
			}
		}

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[Route("create")]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
			if (ModelState.IsValid)
			{
				using (var db = new TodoListDbContext())
				{
					db.Tasks.Add(task);
					db.SaveChanges();
				}
				return RedirectToAction("Index");
			}
			return View(task);
		}

		[HttpGet]
		[Route("delete/{id}")]
        public ActionResult Delete(int? id)
		{
			if (id != null)
			{
				using (var db = new TodoListDbContext())
				{
					var taskToDelete = db.Tasks.Find(id);
					if (taskToDelete != null)
					{
						return View(taskToDelete);
					}
				}
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("delete/{id}")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(int? id, Task taskModel)
		{
				using (var db = new TodoListDbContext())
				{
					var taskToDelete = db.Tasks.Find(id);
					if (taskToDelete != null)
					{
						db.Tasks.Remove(taskToDelete);
						db.SaveChanges();
					}
				}
			return RedirectToAction("Index");
		}
	}
}