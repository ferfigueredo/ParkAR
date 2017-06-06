namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paso2_CargoDatosEnTablas : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into EstadoBoxes (Descripcion) VALUES ('Libre')");
            Sql("Insert into EstadoBoxes (Descripcion) VALUES ('Ocupado')");
            Sql("Insert into EstadoBoxes (Descripcion) VALUES ('Reservado')");
        }
        
        public override void Down()
        {
        }
    }
}
