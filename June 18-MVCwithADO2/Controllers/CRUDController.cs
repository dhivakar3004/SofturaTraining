using MVCwithADO2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithADO2.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        public ActionResult Index()
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.DisplayBook();
            return View("Home",dt);
        }
        public ActionResult Insert()
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.DisplayAuthor();
            return View("Create",dt);
        }
        public ActionResult InsertRecord(FormCollection form,string action)
        {
            if(action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string Title = form["txtTitle"];
                string aname = form["txtAname"];
                Double price = Convert.ToDouble(form["txtPrice"]);
                //int RowIns= model.NewBookAuthorIdName(Title, aname, price);
                int RowIns=model.NewBookAuthorIdNameSecMethod(Title, aname, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult AuthorIndex()
        {
            CRUDModel model = new CRUDModel();
            DataTable dt = model.DisplayAuthor();
            return View("AuthorDisplay", dt);
        }
        public ActionResult EditBook(int BookId)
        {
            CRUDModel model = new CRUDModel();
            DataTable datatable = model.BookbyId(BookId);
            return View("Edit", datatable);
            
        }
        public ActionResult UpdateBook(FormCollection form,string action)
        {
            if (action == "Submit")
            {
                CRUDModel model = new CRUDModel();
                string Title = form["txtTitle"];        
                int Aid = Convert.ToInt32(form["txtAid"]);
                Double Price = Convert.ToDouble(form["txtPrice"]);
                int Bid = Convert.ToInt32(form["txtBid"]);
                int RowUpd = model.UpdateBook(Bid,Title, Aid, Price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult DeleteBook(int Bookid)
        {
            CRUDModel model = new CRUDModel();
            model.DeleteBook(Bookid);
            return RedirectToAction("Index");
        }

      
    }
}