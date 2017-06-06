namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterCategoriaBox : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ValorCategorias", "CategoriaBox_CategoriaBoxId", "dbo.CategoriaBoxes");
            DropIndex("dbo.ValorCategorias", new[] { "CategoriaBox_CategoriaBoxId" });
            DropColumn("dbo.ValorCategorias", "CategoriaBox_CategoriaBoxId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ValorCategorias", "CategoriaBox_CategoriaBoxId", c => c.Int());
            CreateIndex("dbo.ValorCategorias", "CategoriaBox_CategoriaBoxId");
            AddForeignKey("dbo.ValorCategorias", "CategoriaBox_CategoriaBoxId", "dbo.CategoriaBoxes", "CategoriaBoxId");
        }
    }
}
