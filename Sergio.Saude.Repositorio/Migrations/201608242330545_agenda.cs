namespace Sergio.Saude.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agenda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataAgendamento = c.DateTime(),
                        DataAtendimento = c.DateTime(),
                        Status = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medico", t => t.MedicoId)
                .Index(t => t.MedicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "MedicoId", "dbo.Medico");
            DropIndex("dbo.Agenda", new[] { "MedicoId" });
            DropTable("dbo.Agenda");
        }
    }
}
