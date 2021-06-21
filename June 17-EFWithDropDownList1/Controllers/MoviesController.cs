using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFWithDropDownList1.Models;

namespace EFWithDropDownList1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {   
            using(BooksDbEntities mentity = new BooksDbEntities())
            {
                var dataEF = new SelectList(mentity.tbl_movies.ToList(), "S_No", "Movie_Name");
                ViewData["MovEF"] = dataEF;
            }

            using (BooksDbEntities1 bentity= new BooksDbEntities1())
            {
                var bookEF = new SelectList(bentity.tbl_Books.ToList(),"BookId","Title");
                ViewData["BookEF"] = bookEF;
            }
            using (BooksDbEntities1 bentity = new BooksDbEntities1())
            {
                var bookEF = new SelectList(bentity.tbl_Books.ToList(), "BookId", "Title");
                ViewBag.BookEF1= bookEF;
            }
            return View();
        }
        public ActionResult UsingLinq()
        {
            using (BooksDbEntities1 linq = new BooksDbEntities1())
            {
                var res = new SelectList((from book in linq.tbl_Books
                           select book).ToList(),"BookId", "Title");
                ViewData["Moie"] = res;
            }
            
            return View();
        }
    }
}