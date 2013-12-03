using System.Web.Mvc;

namespace Sandbox.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}