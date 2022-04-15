using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalStore.Models;
using DigitalStore.Repository;

namespace DigitalStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Product> _repository;

        public HomeController()
        {
            _repository = new ProductsRepository();
        }

        public HomeController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int? category)
        {
            IEnumerable<Product> products;
            if (category == null)
                products = _repository.GetAll();
            else
                products = _repository.GetAll().Where(p => p.CategoryId == category);
            return View(products);
        }
    }
}