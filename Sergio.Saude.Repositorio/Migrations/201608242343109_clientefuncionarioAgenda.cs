namespace Sergio.Saude.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientefuncionarioAgenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "ClienteId", c => c.Int(nullable: false));
            AddColumn("dbo.Agenda", "FuncionarioId", c => c.Int());
            CreateIndex("dbo.Agenda", "ClienteId");
            CreateIndex("dbo.Agenda", "FuncionarioId");
            AddForeignKey("dbo.Agenda", "ClienteId", "dbo.Cliente", "Id");
            AddForeignKey("dbo.Agenda", "FuncionarioId", "dbo.Funcionario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "FuncionarioId", "dbo.Funcionario");
            DropForeignKey("dbo.Agenda", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Agenda", new[] { "FuncionarioId" });
            DropIndex("dbo.Agenda", new[] { "ClienteId" });
            DropColumn("dbo.Agenda", "FuncionarioId");
            DropColumn("dbo.Agenda", "ClienteId");
        }
    }
}
