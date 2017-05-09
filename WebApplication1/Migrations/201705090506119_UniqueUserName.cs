namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueUserName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Name" });
        }
    }
}
