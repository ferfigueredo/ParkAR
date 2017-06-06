namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBoxModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Boxes", "Categoria_CategoriaBoxId", "dbo.CategoriaBoxes");
            DropIndex("dbo.Boxes", new[] { "Categoria_CategoriaBoxId" });
            RenameColumn(table: "dbo.Boxes", name: "Categoria_CategoriaBoxId", newName: "CategoriaBoxId");
            AlterColumn("dbo.Boxes", "CategoriaBoxId", c => c.Int(nullable: false));
            CreateIndex("dbo.Boxes", "CategoriaBoxId");
            AddForeignKey("dbo.Boxes", "CategoriaBoxId", "dbo.CategoriaBoxes", "CategoriaBoxId", cascadeDelete: true);
            DropColumn("dbo.Boxes", "CategoriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Boxes", "CategoriaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Boxes", "CategoriaBoxId", "dbo.CategoriaBoxes");
            DropIndex("dbo.Boxes", new[] { "CategoriaBoxId" });
            AlterColumn("dbo.Boxes", "CategoriaBoxId", c => c.Int());
            RenameColumn(table: "dbo.Boxes", name: "CategoriaBoxId", newName: "Categoria_CategoriaBoxId");
            CreateIndex("dbo.Boxes", "Categoria_CategoriaBoxId");
            AddForeignKey("dbo.Boxes", "Categoria_CategoriaBoxId", "dbo.CategoriaBoxes", "CategoriaBoxId");
        }
    }
}
