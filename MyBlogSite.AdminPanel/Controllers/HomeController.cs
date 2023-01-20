using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Myblogsite.InterFace;
using Myblogsite.Models;
using MyBlogSite.AdminPanel.Services;
using MyBlogSite.AdminPanel.ViewModels;
using System;
using System.Diagnostics;

namespace MyBlogSite.AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IpostInterface _ipostInterface;
        private readonly ISaveImageInterface _imageInterface;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(IpostInterface ipostInterface,
                                ISaveImageInterface imageInterface,
                                IWebHostEnvironment webHost)
        {
            _ipostInterface = ipostInterface;
            _imageInterface = imageInterface;
            _webHost = webHost;
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
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var post = _ipostInterface.GetById(id);
            _imageInterface.DeleteImage(post.Image);
            _ipostInterface.DeletePost(id);
            return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var post = _ipostInterface.GetById(id);
            return View((PostEditViewModel)post);
        }
        [HttpPost]
        public IActionResult Edit(PostEditViewModel viewModel)
        {
            if (viewModel.NewImage is not null)
            {
                string img = Path.Combine(_webHost.WebRootPath, "photos", viewModel.Image);
                FileInfo info = new FileInfo(img);
                if (info != null)
                {
                    System.IO.File.Delete(img);
                }
                viewModel.Image = _imageInterface.SaveImage(viewModel.NewImage);
            }

            _ipostInterface.UpdatePost((Post)viewModel);

            return RedirectToAction("index");
        }

    }
}