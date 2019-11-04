using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Forum.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection formCollection)
        {
            Post post = new Post();
            post.UserId =1;
            post.DateTime =DateTime.Now;
            post.Title ="";
            post.Body ="";
            return View();
        }
    }
}