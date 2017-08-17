using _11_CS_BookLibrary.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace _11_CS_BookLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
			using (var db = new ApplicationDbContext())
			{
				var books = db.Books.Include(b => b.Author).ToList();
				return View(books);
			}
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
			using (var db = new ApplicationDbContext())
			{
				var book = db.Books
					.Include(b => b.Author)
					.SingleOrDefault(b => b.Id == id);
				if (book == null)
				{
					return new HttpNotFoundResult($"There is no book with ID {id} !");
				}
				return View(book);
			}
        }

        // GET: Book/Create
		[Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Title, Description")] Book book)
        {
			using (var db = new ApplicationDbContext())
			{
				book.AuthorId = User.Identity.GetUserId();
					db.Books.Add(book);
					db.SaveChanges();
					return RedirectToAction("Index");
			}				
		}

		// GET: Book/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
        {
			using (var db = new ApplicationDbContext())
			{
				var book = db.Books.SingleOrDefault(b => b.Id == id);
				if (book == null)
				{
					return new HttpNotFoundResult($"There is no book with ID {id} !");
				}
				var userId = User.Identity.GetUserId();
				if (book.AuthorId != userId)
				{
					return new HttpUnauthorizedResult();
				}
				return View(book);
			}
        }

        // POST: Book/Edit/5
        [HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Book editedBook)
        {
           if (editedBook.Title == null || editedBook.Description == null)
			{
				return View(editedBook);
			}
			using (var db = new ApplicationDbContext())
			{
				var book = db.Books
					.Include(b => b.Author)
					.SingleOrDefault(b => b.Id == id);
				if (book == null)
				{
					return new HttpNotFoundResult($"There is no book with ID {id} !");
				}
				var userId = User.Identity.GetUserId();
				if (book.AuthorId != userId)
				{
					return new HttpUnauthorizedResult();
				}
				book.Title = editedBook.Title;
				book.Description = editedBook.Description;
				db.SaveChanges();
				return RedirectToAction("Details", new { id = id });
			}
        }

        // GET: Book/Delete/5
		[Authorize]
        public ActionResult Delete(int id)
        {
			using (var db = new ApplicationDbContext())
			{
				var book = db.Books.SingleOrDefault(b => b.Id == id);
				if (book == null)
				{
					return new HttpNotFoundResult($"There is no book with ID {id} !");
				}
				var userId = User.Identity.GetUserId();
				if (book.AuthorId != userId)
				{
					return new HttpUnauthorizedResult();
				}
				return View(book);
			}
		}

        // POST: Book/Delete/5
        [HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Book bookToDelete)
        {
			using (var db = new ApplicationDbContext())
			{
				var book = db.Books.SingleOrDefault(b => b.Id == id);
				if (book == null)
				{
					return new HttpNotFoundResult($"There is no book with ID {id} !");
				}
				var userId = User.Identity.GetUserId();
				if (book.AuthorId != userId)
				{
					return new HttpUnauthorizedResult();
				}
				db.Books.Remove(book);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
        }
    }
}
