using System;
using System.Linq;
using System.Web.Mvc;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
        [ValidateInput(false)]
	public class TaskController : Controller
	{
	    [HttpGet]
		[Route("")]
	    public ActionResult Index()
	    {
			using (var db = new TeisterMaskDbContext())
			{
				var tasks = db.Tasks.ToList();
				return View(tasks);
			}
		}

		[HttpGet]
		[Route("create")]
		public ActionResult Create()
		{
			var tempTask = new Task();
			tempTask.Status = "Open";
			tempTask.Title = "";
			return View(tempTask);
		}

		[HttpPost]
		[Route("create")]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Task task)
		{
			if (ModelState.IsValid)
			{
				using (var db = new TeisterMaskDbContext())
				{
					db.Tasks.Add(task);
					db.SaveChanges();
				}
				return RedirectToAction("Index");
			}
			return View(task);
		}

		[HttpGet]
		[Route("edit/{id}")]
		public ActionResult Edit(int? id)
		{
			if (id != null)
			{
				using (var db = new TeisterMaskDbContext())
				{
					var taskToEdit = db.Tasks.Find(id);
					if (taskToEdit != null)
					{
						return View(taskToEdit);
					}
				}
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("edit/{id}")]
		[ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int? id, Task taskModel)
		{
			if (ModelState.IsValid && id != null)
			{
				using (var db = new TeisterMaskDbContext())
				{
					var taskToEdit = db.Tasks.Find(id);
					if (taskToEdit != null)
					{
						taskToEdit.Status = taskModel.Status;
						taskToEdit.Title = taskModel.Title;
						db.SaveChanges();
					}
				}
				return RedirectToAction("Index");
			}
			return View("Edit", taskModel);
		}
	}
}