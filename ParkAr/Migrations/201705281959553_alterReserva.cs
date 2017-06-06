namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterReserva : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservas", "EstadoBox_EstadoBoxId", "dbo.EstadoBoxes");
            DropForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Reservas", new[] { "VehiculoId" });
            DropIndex("dbo.Reservas", new[] { "EstadoBox_EstadoBoxId" });
            AddColumn("dbo.Vehiculoes", "Reserva_ReservaId", c => c.Int());
            CreateIndex("dbo.Vehiculoes", "Reserva_ReservaId");
            AddForeignKey("dbo.Vehiculoes", "Reserva_ReservaId", "dbo.Reservas", "ReservaId");
            DropColumn("dbo.Reservas", "VehiculoId");
            DropColumn("dbo.Reservas", "MyProperty");
            DropColumn("dbo.Reservas", "EstadoBox_EstadoBoxId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservas", "EstadoBox_EstadoBoxId", c => c.Int());
            AddColumn("dbo.Reservas", "MyProperty", c => c.Int(nullable: false));
            AddColumn("dbo.Reservas", "VehiculoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Vehiculoes", "Reserva_ReservaId", "dbo.Reservas");
            DropIndex("dbo.Vehiculoes", new[] { "Reserva_ReservaId" });
            DropColumn("dbo.Vehiculoes", "Reserva_ReservaId");
            CreateIndex("dbo.Reservas", "EstadoBox_EstadoBoxId");
            CreateIndex("dbo.Reservas", "VehiculoId");
            AddForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes", "VehiculoId", cascadeDelete: true);
            AddForeignKey("dbo.Reservas", "EstadoBox_EstadoBoxId", "dbo.EstadoBoxes", "EstadoBoxId");
        }
    }
}
