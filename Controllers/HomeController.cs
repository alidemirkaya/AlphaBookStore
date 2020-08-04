using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphaBookStore.Entities;
using AlphaBookStore.Models;
using AlphaBookStore.Models.ViewModel;
namespace AlphaBookStore.Controllers
{
    public class HomeController : Controller
    {
        public AlphaBookContext dc = new AlphaBookContext();
        public ActionResult Index()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.Books = dc.Books.OrderByDescending(x => x.Id).Take(10).ToList();
            homePageViewModel.Categories = dc.Categories.ToList();
            homePageViewModel.Authors = dc.Authors.ToList();
            return View(homePageViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}