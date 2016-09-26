namespace Garage1._3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        garageId = c.Int(nullable: false, identity: true),
                        Plate = c.String(nullable: false, maxLength: 12),
                        Position = c.Int(nullable: false),
                        UniqueCode = c.Int(nullable: false),
                        TimeOfArrival = c.DateTime(nullable: false),
                        TimeOfDeparture = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.garageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Garages");
        }
    }
}
