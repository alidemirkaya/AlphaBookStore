﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlphaBookStore.Business;
using AlphaBookStore.Entities;
using AlphaBookStore.Models.ViewModel;

namespace AlphaBookStore.Controllers
{
    public class BookController : Controller
    {
        private AlphaBookContext db = new AlphaBookContext();

        // GET: Book
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            var categoryList = BookBusiness.CategorySelectList();
            var authorList = BookBusiness.AuthorSelectList();

            if (categoryList.Any())
            {                
                if (authorList.Any())
                {
                    TempData["categories"] = categoryList;
                    
                    
                }
                else
                {
                    TempData.Add("Alert", "Yazar seçimi yapmadınız");
                }
            }
            else
            {
                TempData.Add("Alert", "Kategori seçimi yapmadınız.");
            }
            ViewBag.Author = authorList;
            ViewBag.Categories = categoryList;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            // Model Kontrol Edilir
            if (ModelState.IsValid)
            {
                var category = db.Categories.Where(x => x.Id == bookViewModel.CategoryId).FirstOrDefault();
                // Kategori Seçimi Kontrol Edilir
                if(category == null)
                {
                    TempData.Add("Alert", "Lütfen kategori seçiniz.");
                    return View();
                }
                else
                {
                    // Yazar Seçimi Kontrol Edilir
                    if (bookViewModel.AuthorId.Length <= 0)
                    {
                        TempData.Add("Alert", "Yazar seçmeniz gerekmektedir.");
                        return View();
                    }
                    else
                    {
                        // Business Sınıfından Başarılı yazısı dönene kadar işlemler devam eder
                        string returnMessage = Business.BookBusiness.CreateBook(bookViewModel);
                        if (returnMessage == "Kayıt Başarılı")
                        {
                            TempData.Add("Alert", returnMessage);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            var categoryList = BookBusiness.CategorySelectList();
                            var authorList = BookBusiness.AuthorSelectList();
                            TempData.Add("Alert", returnMessage);
                            TempData["categories"] = categoryList;
                            ViewBag.Categories = authorList;
                            ViewBag.Author = categoryList;
                            return View();
                        }
                    }                   
                }
            }
            else
            {
                var categoryList = BookBusiness.CategorySelectList();
                var authorList = BookBusiness.AuthorSelectList();
                TempData.Add("Alert", "Bir hata oluştu");
                return Redirect("/Book/create");
            }
           
        }
        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Year,Publisher,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
