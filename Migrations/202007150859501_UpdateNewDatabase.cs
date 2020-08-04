namespace AlphaBookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNewDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books");
            DropIndex("dbo.CategoryBooks", new[] { "Category_Id" });
            DropIndex("dbo.CategoryBooks", new[] { "Book_Id" });
            AddColumn("dbo.Books", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Category_Id");
            AddForeignKey("dbo.Books", "Category_Id", "dbo.Category", "Id", cascadeDelete: true);
            DropTable("dbo.CategoryBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryBooks",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Book_Id });
            
            DropForeignKey("dbo.Books", "Category_Id", "dbo.Category");
            DropIndex("dbo.Books", new[] { "Category_Id" });
            DropColumn("dbo.Books", "Category_Id");
            CreateIndex("dbo.CategoryBooks", "Book_Id");
            CreateIndex("dbo.CategoryBooks", "Category_Id");
            AddForeignKey("dbo.CategoryBooks", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategoryBooks", "Category_Id", "dbo.Category", "Id", cascadeDelete: true);
        }
    }
}
