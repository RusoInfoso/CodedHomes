namespace CodedHomes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InMigrationCheck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Homes", "Bathrooms", c => c.Int(nullable: false));
            AlterColumn("dbo.Homes", "Bedrooms", c => c.Int(nullable: false));
            AlterColumn("dbo.Homes", "SquareFeet", c => c.Int(nullable: false));
            AlterColumn("dbo.Homes", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Homes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Homes", "Description", c => c.String());
            AlterColumn("dbo.Homes", "Price", c => c.Int());
            AlterColumn("dbo.Homes", "SquareFeet", c => c.Int());
            AlterColumn("dbo.Homes", "Bedrooms", c => c.Int());
            AlterColumn("dbo.Homes", "Bathrooms", c => c.Int());
        }
    }
}
