namespace Sergio.Saude.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quarto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "ClienteId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ClienteId", c => c.Int(nullable: false));
        }
    }
}
