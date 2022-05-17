using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
