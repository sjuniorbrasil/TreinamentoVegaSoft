namespace Sergio.Saude.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5777887 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ConsultaExame", new[] { "ClienteId" });
            RenameColumn(table: "dbo.ConsultaExame", name: "ClienteId", newName: "Cliente_Id");
            AddColumn("dbo.ConsultaExame", "MedicoId", c => c.Int(nullable: false));
            AlterColumn("dbo.ConsultaExame", "Cliente_Id", c => c.Int());
            CreateIndex("dbo.ConsultaExame", "Cliente_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ConsultaExame", new[] { "Cliente_Id" });
            AlterColumn("dbo.ConsultaExame", "Cliente_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ConsultaExame", "MedicoId");
            RenameColumn(table: "dbo.ConsultaExame", name: "Cliente_Id", newName: "ClienteId");
            CreateIndex("dbo.ConsultaExame", "ClienteId");
        }
    }
}
