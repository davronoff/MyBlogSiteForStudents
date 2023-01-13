using Microsoft.AspNetCore.Mvc;
using Myblogsite.InterFace;
using Myblogsite.Models;
using MyBlogSite.AdminPanel.Services;
using MyBlogSite.AdminPanel.ViewModels;
using System.Diagnostics;

namespace MyBlogSite.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IpostInterface _ipostInterface;
        private readonly ISaveImageInterface _imageInterface;

        public HomeController(IpostInterface ipostInterface,
                                ISaveImageInterface imageInterface)
        {
            _ipostInterface = ipostInterface;
            _imageInterface = imageInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var all = _ipostInterface.GetAllPosts();
            if(all == null)
            {
                return View("There are nothing");
            }
            return View(all);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PostAddViewModel viewModel)
        {
            Post post = new Post
            {
                Id = Guid.NewGuid(),
                Title = viewModel.Title,
                Time = DateTime.Now,
                Comment = viewModel.Comment,
                Image = _imageInterface.SaveImage(viewModel.Image)
            };
            _ipostInterface.AddPost(post);
            return RedirectToAction("index");
        }

    }
}