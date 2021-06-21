using DDList.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDList.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            BookModel book = new BookModel();
            book.Books = PopulateBooks();
            return View(book);
        }

        [HttpPost]
        public ActionResult Index(BookModel book)
        {
            book.Books = PopulateBooks();
            var selectedItem = book.Books.Find(p => p.Value == book.BookId.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Title: " + selectedItem.Text;
                ViewBag.Message += "\\nQuantity: " + book.Quantity;
            }

            return View(book);
        }
        private static List<SelectListItem> PopulateBooks()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string constr = "Data source=LAPTOP-874O3SVO\\SQLEXPRESS ;database=BooksDb;integrated security=true";
            using(SqlConnection con=new SqlConnection(constr))
            {
                string query = "SELECT Title,Bookid From tbl_Books";
                using (SqlCommand cmd=new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr=cmd.ExecuteReader())
                    {
                        while(sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Title"].ToString(),
                                Value = sdr["BookID"].ToString()

                            });
                        }
                    }
                }con.Close();

            }
            return items;
        }
    }
}