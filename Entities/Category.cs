using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Entities
{   
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public Category()
        {
            this.Books = new HashSet<Book>();
        }
    }
}