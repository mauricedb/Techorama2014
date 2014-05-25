using System.Web.Mvc;

namespace Techorama2014.Controllers
{
    public class DirectivesController : Controller
    {
        // GET: Angular
        public ActionResult EditorTextInput()
        {
            return PartialView();
        }
    }
}