using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Forum.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly PostLogic _postLogic = new PostLogic();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormCollection formCollection)
        {
            Post post = new Post();
            post.UserId = Convert.ToInt16(User.FindFirst("UserId").Value);
            post.DateTime =DateTime.Now;
            post.Title = formCollection["Title"];
            post.Body = formCollection["Body"];

            _postLogic.AddPost(post);
            return RedirectToAction("AllPosts");
        }

        [HttpGet]
        public IActionResult AllPosts()
        {
            var posts = _postLogic.PostOverview();
            return View(posts);
        }

        [HttpGet]
        public ActionResult ViewReplies(Post post)
        {
            var replies = _postLogic.ReplyOverview(post);
            return View(replies);
        }

        [HttpGet]
        public IActionResult CreateReply(int PostId)
        {
            return View(PostId);
        }
    }
}