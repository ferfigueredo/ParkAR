namespace ParkAr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agreguecampoeliminadoacliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehiculoes", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehiculoes", "Eliminado");
        }
    }
}
