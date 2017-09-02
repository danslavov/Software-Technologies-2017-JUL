using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
			using (var db = new ShoppingListDbContext())
			{
				var allProducts = db.Products.ToList();
				return View(allProducts);
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
        public ActionResult Create(Product product)
        {
			if (ModelState.IsValid)
			{
				using (var db = new ShoppingListDbContext())
				{
					db.Products.Add(product);
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
			using (var db = new ShoppingListDbContext())
			{
				var product = db.Products.Find(id);
				if (product == null)
				{
					return RedirectToAction("Index");
				}
				return View(product);
			}
		}

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
			if (ModelState.IsValid && id != null)
			{
				using (var db = new ShoppingListDbContext())
				{
					var productToUpdate = db.Products.Find(id);
					if (productToUpdate != null)
					{
						productToUpdate.Priority = productModel.Priority;
						productToUpdate.Name = productModel.Name;
						productToUpdate.Quantity = productModel.Quantity;
						productToUpdate.Status = productModel.Status;
						db.SaveChanges();
					}
				}
			}
			return RedirectToAction("Index");
		}
    }
}