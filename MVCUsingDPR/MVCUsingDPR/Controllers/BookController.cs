using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCUsingDPR.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;

namespace MVCUsingDPR.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> bookList = new List<BookModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                bookList = dbcon.Query<BookModel>("select * from tbl_Books").ToList();
            }
                return View(bookList);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {

            BookModel book = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                book = dbcon.Query<BookModel>("select * from tbl_Books where BookId=" + id, new { id }).Single();
            }
                return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {   

            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookModel bookmodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string sqlQry = "insert into tbl_Books(Title,AuthorId,Price)" +
                    " Values('" + bookmodel.Title + "'," + bookmodel.AuthorID + "," + bookmodel.Price + ")";
                int rowins=dbcon.Execute(sqlQry);
            }           
            return RedirectToAction("Index");       
                           
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            BookModel book = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                book = dbcon.Query<BookModel>("select * from tbl_Books where BookId=" + id, new { id }).SingleOrDefault();

            }
                return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookModel book)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                string sqlQry = "update tbl_Books set Title='" + book.Title + "',AuthorId=" + book.AuthorID + " ,Price=" + book.Price + "where BookID=" + book.BookID;
                int no_of_rows = dbcon.Execute(sqlQry);
            }
            return RedirectToAction("Index");
        }

      
        public ActionResult Delete(int id)
        {
            BookModel book = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                book = dbcon.Query<BookModel>("delete from tbl_Books where BookId=" + id, new { id }).SingleOrDefault();
            }
            return RedirectToAction("Index");
        }
       
    }
}
