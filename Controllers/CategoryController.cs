using AlphaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaBookStore.Controllers
{
    public class CategoryController : Controller
    {
        public AlphaBookContext dc = new AlphaBookContext();
        // GET: Category
        
        public ActionResult CategoryListForm()
        {
            return View(dc.Categories.ToList());
        }
        public ActionResult CategoryEditForm(int? id)
        {
            var s = dc.Categories.Find(id);
            return View( s);
        }
        [HttpPost]
        public ActionResult CategoryEditForm(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id<=0)
                {
                    dc.Categories.Add(category);
                }
                else
                {
                    dc.Entry(category).State = EntityState.Modified;

                }
                dc.SaveChanges();
                return RedirectToAction("CategoryListForm");
            }
            return View(category);
        }
        public ActionResult Create()
        {
            return View("CategoryEditForm", new Category());
        }
        public ActionResult Edit(int id)
        {
            var s = dc.Categories.Find(id);
            return View("CategoryEditform", s);
        }
    }
}