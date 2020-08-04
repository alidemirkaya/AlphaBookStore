namespace AlphaBookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oylesine : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookAuthors", newName: "BookAuthor");
            RenameColumn(table: "dbo.BookAuthor", name: "Book_Id", newName: "BookRefId");
            RenameColumn(table: "dbo.BookAuthor", name: "Author_Id", newName: "AuthorRefId");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_Book_Id", newName: "IX_BookRefId");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_Author_Id", newName: "IX_AuthorRefId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BookAuthor", name: "IX_AuthorRefId", newName: "IX_Author_Id");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_BookRefId", newName: "IX_Book_Id");
            RenameColumn(table: "dbo.BookAuthor", name: "AuthorRefId", newName: "Author_Id");
            RenameColumn(table: "dbo.BookAuthor", name: "BookRefId", newName: "Book_Id");
            RenameTable(name: "dbo.BookAuthor", newName: "BookAuthors");
        }
    }
}
