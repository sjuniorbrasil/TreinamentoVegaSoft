namespace Sergio.Saude.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segundo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(maxLength: 150, unicode: false),
                        Nome = c.String(maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Funcao = c.String(maxLength: 150, unicode: false),
                        Nome = c.String(maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                        cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.cliente_Id)
                .Index(t => t.cliente_Id);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Crm = c.String(maxLength: 150, unicode: false),
                        Especialidade = c.String(maxLength: 150, unicode: false),
                        Nome = c.String(maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "cliente_Id", "dbo.Cliente");
            DropIndex("dbo.Funcionario", new[] { "cliente_Id" });
            DropTable("dbo.Medico");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Cliente");
        }
    }
}
