using System.Web.Mvc;

namespace _12_CS_Blog.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return RedirectToAction("List", "Article");
		}
	}
}