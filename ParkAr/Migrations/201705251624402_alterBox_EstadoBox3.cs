namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterBox_EstadoBox3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boxes", "EstadoBox_EstadoBoxId", "dbo.EstadoBoxes");
            DropForeignKey("dbo.Boxes", "Estacionamiento_EstacionamientoId", "dbo.Estacionamientoes");
            DropIndex("dbo.Boxes", new[] { "EstadoBox_EstadoBoxId" });
            DropIndex("dbo.Boxes", new[] { "Estacionamiento_EstacionamientoId" });
            RenameColumn(table: "dbo.Boxes", name: "EstadoBox_EstadoBoxId", newName: "EstadoBoxId");
            RenameColumn(table: "dbo.Boxes", name: "Estacionamiento_EstacionamientoId", newName: "EstacionamientoId");
            AlterColumn("dbo.Boxes", "EstadoBoxId", c => c.Int(nullable: false));
            AlterColumn("dbo.Boxes", "EstacionamientoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Boxes", "EstacionamientoId");
            CreateIndex("dbo.Boxes", "EstadoBoxId");
            AddForeignKey("dbo.Boxes", "EstadoBoxId", "dbo.EstadoBoxes", "EstadoBoxId", cascadeDelete: true);
            AddForeignKey("dbo.Boxes", "EstacionamientoId", "dbo.Estacionamientoes", "EstacionamientoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boxes", "EstacionamientoId", "dbo.Estacionamientoes");
            DropForeignKey("dbo.Boxes", "EstadoBoxId", "dbo.EstadoBoxes");
            DropIndex("dbo.Boxes", new[] { "EstadoBoxId" });
            DropIndex("dbo.Boxes", new[] { "EstacionamientoId" });
            AlterColumn("dbo.Boxes", "EstacionamientoId", c => c.Int());
            AlterColumn("dbo.Boxes", "EstadoBoxId", c => c.Int());
            RenameColumn(table: "dbo.Boxes", name: "EstacionamientoId", newName: "Estacionamiento_EstacionamientoId");
            RenameColumn(table: "dbo.Boxes", name: "EstadoBoxId", newName: "EstadoBox_EstadoBoxId");
            CreateIndex("dbo.Boxes", "Estacionamiento_EstacionamientoId");
            CreateIndex("dbo.Boxes", "EstadoBox_EstadoBoxId");
            AddForeignKey("dbo.Boxes", "Estacionamiento_EstacionamientoId", "dbo.Estacionamientoes", "EstacionamientoId");
            AddForeignKey("dbo.Boxes", "EstadoBox_EstadoBoxId", "dbo.EstadoBoxes", "EstadoBoxId");
        }
    }
}
