using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class AuthorController : Controller
    {
        private ILogger<AuthorController> _logger;
        private IRepo<Author> _repo;       
        public AuthorController(IRepo<Author> repo,ILogger<AuthorController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Author> authors = _repo.GetAll().ToList();
            return View(authors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _repo.Add(author);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Author author = _repo.Get(id);
            return View(author);
        }
        public IActionResult Edit(int id,Author author)
        {
            _repo.Update(id,author);
            return RedirectToAction("Index");
        }



    }

}
