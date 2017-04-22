using DAL;
using MenuOnWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuOnWebMVC.Controllers
{
    public class RecipeController : Controller
    {
        MenuOnWebContext db = new MenuOnWebContext();

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            var recipe = db.Recipes.FirstOrDefault(i => i.Id == id);
            if(recipe == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Comments = db.Comments.Where(i => i.RecipeId == id);

            return View((ViewRecipe)recipe);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(ViewRecipe recipe)
        {
            try
            {
                if(recipe.IngridietsString == null)
                {
                    throw new Exception();
                }
                recipe.UpdateTags();
                recipe.UserId = 1;
                Recipe recipeToAdd = (Recipe)recipe;
                db.Recipes.Add(recipeToAdd);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            var recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View((ViewRecipe)recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        public ActionResult Edit(ViewRecipe recipeToEdit)
        {
            try
            {
                if(recipeToEdit.IngridietsString == null)
                {
                    throw new Exception();
                }
                recipeToEdit.UpdateTags();
                Recipe recipeToUpdate = (Recipe)recipeToEdit;
                db.Entry(recipeToUpdate).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            var recipeToDelite = db.Recipes.Find(id);
            if (recipeToDelite == null)
            {
                return HttpNotFound();
            }
            db.Recipes.Remove(recipeToDelite);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
   
    }
}
