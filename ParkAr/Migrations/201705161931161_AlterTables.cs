namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.Int(nullable: false),
                        Email = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.PagoReservas",
                c => new
                    {
                        PagoReservaId = c.Int(nullable: false, identity: true),
                        Monto = c.Int(nullable: false),
                        MedioPago = c.String(),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PagoReservaId);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        ReservaId = c.Int(nullable: false, identity: true),
                        VehiculoId = c.Int(nullable: false),
                        BoxId = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        EstadoBox_EstadoBoxId = c.Int(),
                    })
                .PrimaryKey(t => t.ReservaId)
                .ForeignKey("dbo.Boxes", t => t.BoxId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoBoxes", t => t.EstadoBox_EstadoBoxId)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.BoxId)
                .Index(t => t.EstadoBox_EstadoBoxId);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        VehiculoId = c.Int(nullable: false, identity: true),
                        Patente = c.String(),
                        Modelo = c.String(),
                        Marca = c.String(),
                        TipoVehiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehiculoId)
                .ForeignKey("dbo.TipoVehiculoes", t => t.TipoVehiculoId, cascadeDelete: true)
                .Index(t => t.TipoVehiculoId);
            
            CreateTable(
                "dbo.TipoVehiculoes",
                c => new
                    {
                        TipoVehiculoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoVehiculoId);
            
            AddColumn("dbo.Estacionamientoes", "Nombre", c => c.String());
            AlterColumn("dbo.ValorCategorias", "FechaDesde", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.ValorCategorias", "FechaHasta", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "TipoVehiculoId", "dbo.TipoVehiculoes");
            DropForeignKey("dbo.Reservas", "EstadoBox_EstadoBoxId", "dbo.EstadoBoxes");
            DropForeignKey("dbo.Reservas", "BoxId", "dbo.Boxes");
            DropIndex("dbo.Vehiculoes", new[] { "TipoVehiculoId" });
            DropIndex("dbo.Reservas", new[] { "EstadoBox_EstadoBoxId" });
            DropIndex("dbo.Reservas", new[] { "BoxId" });
            DropIndex("dbo.Reservas", new[] { "VehiculoId" });
            AlterColumn("dbo.ValorCategorias", "FechaHasta", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ValorCategorias", "FechaDesde", c => c.DateTime(nullable: false));
            DropColumn("dbo.Estacionamientoes", "Nombre");
            DropTable("dbo.TipoVehiculoes");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Reservas");
            DropTable("dbo.PagoReservas");
            DropTable("dbo.Clientes");
        }
    }
}
