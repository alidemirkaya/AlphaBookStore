using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Web;

namespace AlphaBookStore.Entities
{
    public class AlphaBookContext:DbContext
    {
        public AlphaBookContext() : base("name=AlphaBookConnectionString")
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
              .HasMany<Author>(s => s.Authors)
              .WithMany(c => c.Books)
              .Map(cs =>
              {
                  cs.MapLeftKey("BookRefId");
                  cs.MapRightKey("AuthorRefId");
                  cs.ToTable("BookAuthor");
              });
        }
    }
}