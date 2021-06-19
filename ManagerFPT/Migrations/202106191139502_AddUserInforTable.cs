namespace ManagerFPT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInforTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfors",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        NumberPhone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfors", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserInfors", new[] { "UserId" });
            DropTable("dbo.UserInfors");
        }
    }
}
