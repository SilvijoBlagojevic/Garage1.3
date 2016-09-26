namespace Garage1._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Garages", "TimeOfDeparture", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Garages", "TimeOfDeparture", c => c.DateTime(nullable: false));
        }
    }
}
