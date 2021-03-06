﻿using Microsoft.AspNetCore.Mvc;
using News.Mvc.Client.Models;

namespace News.Mvc.Client.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            var allNews = Service.GetAllNews();
            return View(allNews);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewsBindingModel model)
        {
            var postNews = Service.PostNews(model);
            return RedirectToAction(postNews ? nameof(Index) : nameof(Create));
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(BaseModel model)
        {
            var deleteNews = Service.Delete(model);
            return RedirectToAction(nameof(Result), new {message = deleteNews});
        }

        public IActionResult Result(string message)
        {
            return View("Result", message);
        }
    }
}