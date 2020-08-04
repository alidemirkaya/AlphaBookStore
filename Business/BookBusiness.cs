using AlphaBookStore.Entities;
using AlphaBookStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlphaBookStore.Business
{
    public class BookBusiness
    {
        
        public static string CreateBook(BookViewModel bookViewModel)
        {
            try
            {
                using (AlphaBookContext dc = new AlphaBookContext())
                {
                    var category = dc.Categories.Where(x => x.Id == bookViewModel.CategoryId).FirstOrDefault();
                    var book = new Book
                    {
                        Category = category,
                        Name = bookViewModel.Name,
                        Price = bookViewModel.Price,
                        Publisher = bookViewModel.Publisher,
                        Year = bookViewModel.Year
                    };
                    List<Author> authors = new List<Author>();
                    var test = dc.Authors.Where(x => bookViewModel.AuthorId.Contains(x.Id)).ToList();

                    //foreach (var deg in bookViewModel.AuthorId)
                    //{
                    //    authors.Add(new Author { Id = deg });
                    //    //var findAuthor = dc.Authors.Find(deg);
                    //    //authors.Add(findAuthor);
                    //}
                    book.Authors = test;
                    dc.Books.Add(book);
                    
                    dc.SaveChanges();
                    string message = "Kayıt Başarılı";
                    return message;
                }

            }
            catch (Exception en)
            {              
                return en.ToString();
            }
        }
        public static List<SelectListItem> CategorySelectList()
        {
            using (AlphaBookContext dc = new AlphaBookContext())
            {
                var categories = new List<SelectListItem>();
                categories = dc.Categories.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
                return categories;
            }
        }
        public static List<SelectListItem> AuthorSelectList()
        {
            using (AlphaBookContext dc = new AlphaBookContext())
            {
                var authors = new List<SelectListItem>();
                authors = dc.Authors.Select(x => new SelectListItem
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.Id.ToString()
                }).ToList();
                return authors;
            }
        }
    }
}