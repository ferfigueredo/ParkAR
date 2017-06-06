namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarEstadoAReserva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservas", "EstadoReserva_EstadoReservaId", c => c.Int());
            CreateIndex("dbo.Reservas", "EstadoReserva_EstadoReservaId");
            AddForeignKey("dbo.Reservas", "EstadoReserva_EstadoReservaId", "dbo.EstadoReservas", "EstadoReservaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "EstadoReserva_EstadoReservaId", "dbo.EstadoReservas");
            DropIndex("dbo.Reservas", new[] { "EstadoReserva_EstadoReservaId" });
            DropColumn("dbo.Reservas", "EstadoReserva_EstadoReservaId");
        }
    }
}
