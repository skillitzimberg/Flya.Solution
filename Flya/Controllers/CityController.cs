using Microsoft.AspNetCore.Mvc;

namespace Flya.Controllers
{
    public class CityController : Controller
    {
        [HttpGet("/cities")]
        public ActionResult Index()
        {
          return View();
        }

    }
}
