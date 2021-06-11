namespace ManagerFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            AlterColumn("dbo.Categories", "Description", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropTable("dbo.Courses");
        }
    }
}
