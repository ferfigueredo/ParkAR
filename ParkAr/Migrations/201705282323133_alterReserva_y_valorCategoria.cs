namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterReserva_y_valorCategoria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehiculoes", "Reserva_ReservaId", "dbo.Reservas");
            DropIndex("dbo.Vehiculoes", new[] { "Reserva_ReservaId" });
            AddColumn("dbo.Reservas", "FechaDesde", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservas", "FechaHasta", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservas", "Vehiculo_VehiculoId", c => c.Int());
            CreateIndex("dbo.Reservas", "Vehiculo_VehiculoId");
            AddForeignKey("dbo.Reservas", "Vehiculo_VehiculoId", "dbo.Vehiculoes", "VehiculoId");
            DropColumn("dbo.Vehiculoes", "Reserva_ReservaId");
            DropColumn("dbo.ValorCategorias", "FechaDesde");
            DropColumn("dbo.ValorCategorias", "FechaHasta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ValorCategorias", "FechaHasta", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ValorCategorias", "FechaDesde", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Vehiculoes", "Reserva_ReservaId", c => c.Int());
            DropForeignKey("dbo.Reservas", "Vehiculo_VehiculoId", "dbo.Vehiculoes");
            DropIndex("dbo.Reservas", new[] { "Vehiculo_VehiculoId" });
            DropColumn("dbo.Reservas", "Vehiculo_VehiculoId");
            DropColumn("dbo.Reservas", "FechaHasta");
            DropColumn("dbo.Reservas", "FechaDesde");
            CreateIndex("dbo.Vehiculoes", "Reserva_ReservaId");
            AddForeignKey("dbo.Vehiculoes", "Reserva_ReservaId", "dbo.Reservas", "ReservaId");
        }
    }
}
