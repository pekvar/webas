namespace WebAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropForeignKeyFromLocation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Locations", new[] { "AddressId" });
            DropColumn("dbo.Locations", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "AddressId", c => c.Int());
            CreateIndex("dbo.Locations", "AddressId");
            AddForeignKey("dbo.Locations", "AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
