using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using task1inWebApp.Models;
using task1inWebApp.Services;

namespace task1inWebApp.Controllers
{ public class UserController : Controller
    {
        private readonly IUserRepo<UserModel> _repo;
        public UserController(IUserRepo<UserModel> repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (TempData.Count == 0)
                return View();
            UserModel user = new UserModel();
            user.UserName = TempData.Peek("un").ToString();
            return View(user);        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            try
            {
                if (_repo.Login(user))
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel user)
        {
            try
            {   
                _repo.Register(user);
                TempData["un"] = user.UserName;
                return RedirectToAction("Login");
            }
            catch
            {

                return View();
            }
        }
    } 
}