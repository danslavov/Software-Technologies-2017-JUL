using System.Linq;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.Controllers
{
    [ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
			using (var db = new IMDBDbContext())
			{
				var allFilms = db.Films.ToList();
				return View(allFilms);
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
		public ActionResult Create(Film film)
		{
			if (ModelState.IsValid)
			{
				using (var db = new IMDBDbContext())
				{
					db.Films.Add(film);
					db.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("edit/{id}")]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}
			using(var db = new IMDBDbContext())
			{
				var film = db.Films.Find(id);
				if (film == null)
				{
					return RedirectToAction("Index");
				}
				return View(film);
			}
		}

		[HttpPost]
		[Route("edit/{id}")]
		[ValidateAntiForgeryToken]
		public ActionResult EditConfirm(int? id, Film filmModel)
		{
			if (ModelState.IsValid && id != null)
			{
				using (var db = new IMDBDbContext())
				{
					var filmToUpdate = db.Films.Find(id);
					if (filmToUpdate != null)
					{
						filmToUpdate.Name = filmModel.Name;
						filmToUpdate.Genre = filmModel.Genre;
						filmToUpdate.Director = filmModel.Director;
						filmToUpdate.Year = filmModel.Year;
						db.SaveChanges();
					}
				}
			}
				return RedirectToAction("Index");
		}

		[HttpGet]
		[Route("delete/{id}")]
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Index");
			}
			using (var db = new IMDBDbContext())
			{
				var film = db.Films.Find(id);
				if (film == null)
				{
					return RedirectToAction("Index");
				}
				return View(film);
			}
		}

		[HttpPost]
		[Route("delete/{id}")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirm(int? id, Film filmModel)
		{
			if (id != null)
			{
				using (var db = new IMDBDbContext())
				{
					var film = db.Films.Find(id);
					db.Films.Remove(film);
					db.SaveChanges();
				}
			}
			return RedirectToAction("Index");
		}
	}
}