namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vehiculos_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "VehiculoPrincipal", c => c.Int(nullable: false));
            AddColumn("dbo.Vehiculoes", "cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.Vehiculoes", "cliente_ClienteId");
            AddForeignKey("dbo.Vehiculoes", "cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculoes", "cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Vehiculoes", new[] { "cliente_ClienteId" });
            DropColumn("dbo.Vehiculoes", "cliente_ClienteId");
            DropColumn("dbo.Clientes", "VehiculoPrincipal");
        }
    }
}
