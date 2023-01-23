using Microsoft.AspNetCore.Mvc;
using Myblogsite.InterFace;
using System.Diagnostics;

namespace myblogsite.Controllers
{
    public class HomeController : Controller
    {
		private readonly IpostInterface _ipostInterface;

		public HomeController(IpostInterface ipostInterface)
        {
            _ipostInterface = ipostInterface;

		}
        [HttpGet]
        public IActionResult Index()
        {
            var all = _ipostInterface.GetAllPosts();
            return View(all);
        }
    }
}