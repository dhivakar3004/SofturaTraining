using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstWebApplication.Controllers
{
    public class PostController : Controller
    {
        static List<Post> posts = new List<Post>()
        {
        new Post(){Id = 101,PostText = "Check the status of movies on may14",Category = "Flim" },
        new Post() { Id = 102,PostText = "Always wash hands with soap",Category = "Health" },
        new Post() { Id = 103,PostText = "New Arrivals!!! Rose Milk",Category = "Food" }
         };

        public IActionResult Index()
        {
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            posts.Add(post);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            int idx = posts.FindIndex(p => p.Id == id);
            return View(posts[idx]);
        }    
        [HttpPost]
        public IActionResult Edit(int id, Post post)
        {
            int idx = posts.FindIndex(p => p.Id == id);
            posts[idx].PostText = post.PostText;
            posts[idx].Category = post.Category;
            return RedirectToAction("Index");

        }
    }
}
