namespace Sergio.Saude.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _987875 : DbMigration
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
                "dbo.ConsultaExame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsultaId = c.Int(nullable: false),
                        ExameId = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataColeta = c.DateTime(nullable: false),
                        DataEmissao = c.DateTime(nullable: false),
                        ProximaConsulta = c.DateTime(nullable: false),
                        SituacaoExame = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 150, unicode: false),
                        Cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.Consulta", t => t.ConsultaId)
                .ForeignKey("dbo.Exames", t => t.ExameId)
                .Index(t => t.ConsultaId)
                .Index(t => t.ExameId)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Consulta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataAgendamento = c.DateTime(),
                        DataAgendado = c.DateTime(),
                        SituacaoAgenda = c.Int(nullable: false),
                        ClienteId = c.Long(nullable: false),
                        FuncionarioId = c.Long(nullable: false),
                        DataConsulta = c.DateTime(),
                        DataEncaminhado = c.DateTime(),
                        SituacaoConsulta = c.Int(nullable: false),
                        ValorConsulta = c.Decimal(precision: 18, scale: 2),
                        FormaPagamento = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 150, unicode: false),
                        Cliente_Id = c.Int(),
                        Funcionario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.Funcionarios", t => t.Funcionario_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Funcionario_Id);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Funcao = c.String(maxLength: 150, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                        cliente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.cliente_Id)
                .Index(t => t.cliente_Id);
            
            CreateTable(
                "dbo.Exames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 150, unicode: false),
                        Valor = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Crm = c.String(maxLength: 150, unicode: false),
                        Especialidade = c.String(maxLength: 150, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsultaExame", "ExameId", "dbo.Exames");
            DropForeignKey("dbo.Consulta", "Funcionario_Id", "dbo.Funcionarios");
            DropForeignKey("dbo.Funcionarios", "cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.ConsultaExame", "ConsultaId", "dbo.Consulta");
            DropForeignKey("dbo.Consulta", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.ConsultaExame", "Cliente_Id", "dbo.Cliente");
            DropIndex("dbo.Funcionarios", new[] { "cliente_Id" });
            DropIndex("dbo.Consulta", new[] { "Funcionario_Id" });
            DropIndex("dbo.Consulta", new[] { "Cliente_Id" });
            DropIndex("dbo.ConsultaExame", new[] { "Cliente_Id" });
            DropIndex("dbo.ConsultaExame", new[] { "ExameId" });
            DropIndex("dbo.ConsultaExame", new[] { "ConsultaId" });
            DropTable("dbo.Medicos");
            DropTable("dbo.Exames");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Consulta");
            DropTable("dbo.ConsultaExame");
            DropTable("dbo.Cliente");
        }
    }
}
