using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Models.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public int CategoryId { get; set; }
        public int[] AuthorId { get; set; }
    }
}