namespace WebAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressIdToLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "AddressId", c => c.Int());
            CreateIndex("dbo.Locations", "AddressId");
            AddForeignKey("dbo.Locations", "AddressId", "dbo.Addresses", "AddressId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Locations", new[] { "AddressId" });
            DropColumn("dbo.Locations", "AddressId");
        }
    }
}
