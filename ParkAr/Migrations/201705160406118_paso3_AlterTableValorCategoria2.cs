namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paso3_AlterTableValorCategoria2 : DbMigration
    {
        public override void Up()
        {
            Sql("Alter table [ValorCategorias] alter column[FechaDesde] Time NOT NULL");
            Sql("Alter table [ValorCategorias] alter column[FechaHasta] Time NOT NULL");
        }
        
        public override void Down()
        {
        }
    }
}
