namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paso1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        BoxId = c.Int(nullable: false, identity: true),
                        Piso = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        EstadoBoxId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                        Categoria_CategoriaBoxId = c.Int(),
                        Estacionamiento_EstacionamientoId = c.Int(),
                    })
                .PrimaryKey(t => t.BoxId)
                .ForeignKey("dbo.CategoriaBoxes", t => t.Categoria_CategoriaBoxId)
                .ForeignKey("dbo.EstadoBoxes", t => t.EstadoBoxId, cascadeDelete: true)
                .ForeignKey("dbo.Estacionamientoes", t => t.Estacionamiento_EstacionamientoId)
                .Index(t => t.EstadoBoxId)
                .Index(t => t.Categoria_CategoriaBoxId)
                .Index(t => t.Estacionamiento_EstacionamientoId);
            
            CreateTable(
                "dbo.CategoriaBoxes",
                c => new
                    {
                        CategoriaBoxId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaBoxId);
            
            CreateTable(
                "dbo.ValorCategorias",
                c => new
                    {
                        ValorCategoriaId = c.Int(nullable: false, identity: true),
                        Monto = c.Int(nullable: false),
                        FechaDesde = c.DateTime(nullable: false),
                        FechaHasta = c.DateTime(nullable: false),
                        CategoriaBox_CategoriaBoxId = c.Int(),
                    })
                .PrimaryKey(t => t.ValorCategoriaId)
                .ForeignKey("dbo.CategoriaBoxes", t => t.CategoriaBox_CategoriaBoxId)
                .Index(t => t.CategoriaBox_CategoriaBoxId);
            
            CreateTable(
                "dbo.EstadoBoxes",
                c => new
                    {
                        EstadoBoxId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EstadoBoxId);
            
            CreateTable(
                "dbo.Estacionamientoes",
                c => new
                    {
                        EstacionamientoId = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.EstacionamientoId);
            
            CreateTable(
                "dbo.EstadoReservas",
                c => new
                    {
                        EstadoReservaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EstadoReservaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Boxes", "Estacionamiento_EstacionamientoId", "dbo.Estacionamientoes");
            DropForeignKey("dbo.Boxes", "EstadoBoxId", "dbo.EstadoBoxes");
            DropForeignKey("dbo.Boxes", "Categoria_CategoriaBoxId", "dbo.CategoriaBoxes");
            DropForeignKey("dbo.ValorCategorias", "CategoriaBox_CategoriaBoxId", "dbo.CategoriaBoxes");
            DropIndex("dbo.ValorCategorias", new[] { "CategoriaBox_CategoriaBoxId" });
            DropIndex("dbo.Boxes", new[] { "Estacionamiento_EstacionamientoId" });
            DropIndex("dbo.Boxes", new[] { "Categoria_CategoriaBoxId" });
            DropIndex("dbo.Boxes", new[] { "EstadoBoxId" });
            DropTable("dbo.EstadoReservas");
            DropTable("dbo.Estacionamientoes");
            DropTable("dbo.EstadoBoxes");
            DropTable("dbo.ValorCategorias");
            DropTable("dbo.CategoriaBoxes");
            DropTable("dbo.Boxes");
        }
    }
}
