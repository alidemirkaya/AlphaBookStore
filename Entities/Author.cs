using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            this.Books = new HashSet<Book>();
        }
    }
}