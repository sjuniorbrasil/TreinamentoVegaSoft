namespace Sergio.Saude.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class terceiro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Cidade", c => c.String());
            AddColumn("dbo.AspNetUsers", "ClienteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ClienteId");
            DropColumn("dbo.AspNetUsers", "Cidade");
        }
    }
}
