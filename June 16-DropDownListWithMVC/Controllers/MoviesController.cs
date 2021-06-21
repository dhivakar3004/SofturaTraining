using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownListWithMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            #region ViewBag
            List<SelectListItem> Mlist = new List<SelectListItem>()
            {      new SelectListItem{Text="Diwali" ,Value="1"},
                   new SelectListItem{Text="Petta" ,Value="2"},
                   new SelectListItem{Text="Thuppakki" ,Value="3"},
                   new SelectListItem{Text="7 am Arivu" ,Value="4"},
                   new SelectListItem{Text="24" ,Value="5"},
                   new SelectListItem{Text="Karnan" ,Value="6"},
                   new SelectListItem{Text="Panga" ,Value="7"},
                   new SelectListItem{Text="Dhoni" ,Value="8"}
            };
            ViewBag.MovList = Mlist;
            #endregion


            #region ViewData
            List<SelectListItem> Mvdlist = new List<SelectListItem>()
            {
                   new SelectListItem{Text="Valimai" ,Value="0"},
                   new SelectListItem{Text="Diwali" ,Value="1"},
                   new SelectListItem{Text="Petta" ,Value="2"},
                   new SelectListItem{Text="Thuppakki" ,Value="3"},
                   new SelectListItem{Text="7 am Arivu" ,Value="4"},
                   new SelectListItem{Text="24" ,Value="5"},
                   new SelectListItem{Text="Karnan" ,Value="6"},
                   new SelectListItem{Text="Panga" ,Value="7"},
                   new SelectListItem{Text="Dhoni" ,Value="8"}
            };
            ViewData["MovdataList"] = Mvdlist;
            #endregion



            #region TempData
            List<SelectListItem> Mvtlist = new List<SelectListItem>()
            {
                   new SelectListItem{Text="Valimai" ,Value="0"},
                   new SelectListItem{Text="Diwali" ,Value="1"},
                   new SelectListItem{Text="Petta" ,Value="2"},
                   new SelectListItem{Text="Thuppakki" ,Value="3"},
                   new SelectListItem{Text="7 am Arivu" ,Value="4"},
                   new SelectListItem{Text="24" ,Value="5"},
                   new SelectListItem{Text="Karnan" ,Value="6"},
                   new SelectListItem{Text="Panga" ,Value="7"},
                   new SelectListItem{Text="Dhoni" ,Value="8"}
            };
            TempData["MovTempList"] = Mvtlist;
            #endregion

            var Molist = new List<ConvertMovList>();
            foreach(MovieList ml in Enum.GetValues(typeof(MovieList)))
            {
                Molist.Add(new ConvertMovList
                {
                    Value = (int) ml,
                    Text = ml.ToString()
                });
            }
            ViewBag.EnumMl = Molist;
            return View();
        }
        public enum MovieList
         {
            orphan,
            Night_at_the_Museum,
            Cuckoos_Nest,
            Memento,
            Sound_of_Music,
            True_Story,
            The_Juror,
            GoneGirl,
            why_Him
         }

        public struct ConvertMovList
        {
            public int Value { get; set; }

            public string Text { get; set; }

            
        }
    }
}