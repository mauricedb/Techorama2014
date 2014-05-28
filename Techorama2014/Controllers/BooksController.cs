using System.Web.Mvc;

namespace Techorama2014.Controllers
{
#if !DEBUG
    [OutputCache(Duration = 3600)]
#endif
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