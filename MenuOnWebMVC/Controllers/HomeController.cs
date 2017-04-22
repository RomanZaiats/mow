using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using MenuOnWebMVC.Models;

namespace MenuOnWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MenuOnWebContext db = new MenuOnWebContext();
            List<ViewRecipe> recipes = new List<ViewRecipe>();
            foreach (var item in db.Recipes)
            {
                recipes.Add((ViewRecipe)item);
            }
            ViewBag.Recipes = recipes;

            return View();
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