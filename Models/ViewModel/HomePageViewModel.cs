using AlphaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Models.ViewModel
{
    public class HomePageViewModel
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
    }
}