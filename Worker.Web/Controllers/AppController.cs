using Microsoft.AspNetCore.Mvc;

namespace Worker.Web.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
    }
}
