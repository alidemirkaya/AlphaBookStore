using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public List<Author> Authors { get; set; }
    }
}