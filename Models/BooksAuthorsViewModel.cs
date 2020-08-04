using AlphaBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Models
{
    public class BooksAuthorsViewModel
    {
        public List<Author> Authors { get; set; }
        public List<Book> Books { get; set; }
    }
}