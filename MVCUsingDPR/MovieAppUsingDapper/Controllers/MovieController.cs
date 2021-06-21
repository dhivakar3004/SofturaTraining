using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using MovieAppUsingDapper.Models;

namespace MovieAppUsingDapper.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<MovieModel> movmodlist = new List<MovieModel>();
            using(IDbConnection dbcon=new SqlConnection (ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                movmodlist = dbcon.Query<MovieModel>("Select * from tbl_movies").ToList();

            }           

            return View(movmodlist);
        }
        public ActionResult Details(int id)
        {

            MovieModel mod = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                mod=dbcon.Query<MovieModel>("Select * from tbl_movies where S_No=" + id, new { id }).Single();
            }
                return View(mod);
        }
        public ActionResult Create()
        {

            return View();
        }

       
        [HttpPost]
        public ActionResult Create(MovieModel moviemodel)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                string sqlQry = "insert into tbl_movies(Movie_Name)" +
                    " Values('" + moviemodel.Movie_Name + "' )";
                int rowins = dbcon.Execute(sqlQry);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            MovieModel movmod = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                movmod = dbcon.Query<MovieModel>("select * from tbl_movies where S_No=" + id, new { id }).SingleOrDefault();

            }
            return View(movmod);
        }

     
        [HttpPost]
        public ActionResult Edit(MovieModel movmod)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                string sqlQry = "update tbl_movies set Movie_Name='" + movmod.Movie_Name + "'where S_No =" + movmod.S_No;
                int no_of_rows = dbcon.Execute(sqlQry);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            MovieModel movmod = new MovieModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                movmod = dbcon.Query<MovieModel>("delete from tbl_movies where S_No=" + id, new { id }).SingleOrDefault();
            }
            return RedirectToAction("Index");
        }

    }
}