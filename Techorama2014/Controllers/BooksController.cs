using System.Web.Mvc;

namespace Techorama2014.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView();
        }

        public ActionResult Editor()
        {
            return PartialView("Editor1");
        }
    }
}