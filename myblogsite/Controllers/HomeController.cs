using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace myblogsite.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}