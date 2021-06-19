namespace ManagerFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserInfors", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.UserInfors", "DepartmentId", c => c.Int());
            AddColumn("dbo.UserInfors", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserInfors", "DepartmentId");
            AddForeignKey("dbo.UserInfors", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfors", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.UserInfors", new[] { "DepartmentId" });
            DropColumn("dbo.UserInfors", "Discriminator");
            DropColumn("dbo.UserInfors", "DepartmentId");
            DropColumn("dbo.UserInfors", "Age");
            DropTable("dbo.Departments");
        }
    }
}
