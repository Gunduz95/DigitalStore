using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalStore.Models;
using DigitalStore.Repository;

namespace DigitalStore.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository<Product> _repository;
        private IRepository<Category> _categories;
        private IRepository<Manufacturer> _manufacturers;

        public ProductsController()
        {
            _repository = new ProductsRepository();
            _categories = new CategoryRepository();
            _manufacturers = new ManufacturersRepository();
        }

        public ProductsController(IRepository<Product> repository, 
            IRepository<Category> categories, 
            IRepository<Manufacturer> manufacturers)
        {
            _repository = repository;
            _categories = categories;
            _manufacturers = manufacturers;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categories.GetAll(), "Id", "Name");
            ViewBag.ManufacturerId = new SelectList(_manufacturers.GetAll(), "Id", "Name");
            return View("Create");
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CategoryId,ManufacturerId,Price")] Product product,
            HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                _repository.Create(product);
                _repository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_categories.GetAll(), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_manufacturers.GetAll(), "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        [AllowAnonymous]
        public ActionResult GetImage(int productId)
        {
            Product product = _repository.GetById(productId);

            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(_categories.GetAll(), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_manufacturers.GetAll(), "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryId,ManufacturerId,Price")] Product product,
            HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                _repository.Update(product);
                _repository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_categories.GetAll(), "Id", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_manufacturers.GetAll(), "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
