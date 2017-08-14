using _11_CS_ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _11_CS_ToDo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var db = new TaskDbContext())
			{
				var tasks = db.Tasks.ToList();
				return View(tasks);
			}
				
		}
	}
}