using System.Net;
using System.Web.Mvc;
using DigitalStore.Models;
using DigitalStore.Repository;

namespace DigitalStore.Controllers
{
    public class ManufacturersController : Controller
    {
        private IRepository<Manufacturer> _repository;

        public ManufacturersController()
        {
            _repository = new ManufacturersRepository();
        }

        public ManufacturersController(IRepository<Manufacturer> repository)
        {
            _repository = repository;
        }

        // GET: Manufacturers
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Manufacturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _repository.GetById(id.Value);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Manufacturers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(manufacturer);
                _repository.Save();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        // GET: Manufacturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _repository.GetById(id.Value);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(manufacturer);
                _repository.Save();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = _repository.GetById(id.Value);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Delete/5
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
