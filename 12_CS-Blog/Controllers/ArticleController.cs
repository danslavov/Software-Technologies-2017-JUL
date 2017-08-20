using _12_CS_Blog.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace _12_CS_Blog.Controllers
{
	public class ArticleController : Controller
	{
		//
		// GET: Article
		public ActionResult Index()
		{
			return RedirectToAction("List");
		}

		//
		//GET: Article/List
		public ActionResult List()
		{
			using (var db = new BlogDbContext())
			{
				var articles = db.Articles
					.Include(a => a.Author)
					.ToList();
				return View(articles);
			}
		}

		//
		//GET: Article/Details
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			using (var db = new BlogDbContext())
			{
				var article = db.Articles
					.Where(a => a.Id == id)
					.Include(a => a.Author)
					.First();
				return View(article);
			}
		}

		//
		//GET: Article/Create
		[Authorize]
		public ActionResult Create()
		{
			return View();
		}

		//
		//POST: Article/Create
		[HttpPost]
		[Authorize]
		public ActionResult Create(Article article)
		{
			if (ModelState.IsValid)
			{
				using (var db = new BlogDbContext())
				{
					var authorId = db.Users
						.Where(u => u.UserName == this.User.Identity.Name)
						.First()
						.Id;
					article.AuthorId = authorId;
					db.Articles.Add(article);
					db.SaveChanges();

					return RedirectToAction("Index");
				}
			}

			return View(article);
		}

		//
		//Get: Article/Delete
		public ActionResult Delete(int? id)
		{
			using (var db = new BlogDbContext())
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}

				var article = db.Articles
					.Where(a => a.Id == id)
					.Include(a => a.Author)
					.First();

				if (article == null)
				{
					return HttpNotFound();
				}

				if (!UserCanEdit(article))
				{
					return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
				}

				return View(article);
			}
		}

		//
		//Post: Article/Delete
		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeleteResult(int? id)
		{
			using (var db = new BlogDbContext())
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}

				var article = db.Articles
					.Where(a => a.Id == id)
					.Include(a => a.Author)
					.First();

				if (article == null)
				{
					return HttpNotFound();
				}

				db.Articles.Remove(article);
				db.SaveChanges();

				return RedirectToAction("Index");
			}
		}

		//
		//Get: Article/Edit
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			using (var db = new BlogDbContext())
			{
				var article = db.Articles
					.Where(a => a.Id == id)
					.First();

				if (article == null)
				{
					return HttpNotFound();
				}

				if (!UserCanEdit(article))
				{
					return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
				}

				var model = new ArticleViewModel();
				model.Id = article.Id;
				model.Title = article.Title;
				model.Content = article.Content;

				return View(model);
			}
		}

		//
		//Post: Article/Edit
		[HttpPost]
		public ActionResult Edit(ArticleViewModel model)
		{
			if (ModelState.IsValid)
			{
				using (var db = new BlogDbContext())
				{
					var article = db.Articles
						.FirstOrDefault(a => a.Id == model.Id);

					article.Title = model.Title;
					article.Content = model.Content;

					db.Entry(article).State = EntityState.Modified;
					db.SaveChanges();

					return RedirectToAction("Index");
				}
			}

			return View(model);
		}

		public bool UserCanEdit(Article article)
		{
			bool isAdmin = this.User.IsInRole("Admin");
			bool isAuthor = article.IsAuthor(this.User.Identity.Name);
			return isAuthor || isAdmin;
		}
	}
}