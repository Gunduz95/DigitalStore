using System.Net;
using System.Web;
using System.Web.Mvc;
using DigitalStore.Models;
using DigitalStore.Repository;

namespace DigitalStore.Controllers
{
    public class SideBarController : Controller
    {
        private IRepository<Category> _repository;

        public SideBarController()
        {
            _repository = new CategoryRepository();
        }

        public SideBarController(IRepository<Category> repository)
        {
            _repository = repository;
        }
        // GET: SideBar
        public ActionResult Index()
        {            
            return PartialView(_repository.GetAll());
        }
    }
}