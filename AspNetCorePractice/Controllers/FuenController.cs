using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePractice.Controllers
{
    public class FuenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
