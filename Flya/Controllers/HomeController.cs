using Microsoft.AspNetCore.Mvc;

namespace Flya.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
