using _11_CS_ToDo.Models;
using System.Web.Mvc;

namespace _11_CS_ToDo.Controllers
{
    public class TaskController : Controller
    {
		[HttpPost]
		public ActionResult Create(Task task)
		{
			if (task != null)
			{
				using (var db = new TaskDbContext())
				{
					db.Tasks.Add(task);
					db.SaveChanges();
				}
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public ActionResult Delete(int? id)
		{
			if (id != null)
			{
				using (var db = new TaskDbContext())
				{
					var task = db.Tasks.Find(id);
					if (task == null)
					{
						goto here;
					}
					db.Tasks.Remove(task);
					db.SaveChanges();
				}
			}
			here:
			return RedirectToAction("Index", "Home");
		}
    }
}