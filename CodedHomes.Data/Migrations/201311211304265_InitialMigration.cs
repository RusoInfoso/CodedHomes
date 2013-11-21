namespace CodedHomes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(nullable: false, maxLength: 100),
                        StreetAddress2 = c.String(maxLength: 100),
                        City = c.String(nullable: false, maxLength: 50),
                        ZipCode = c.Int(nullable: false),
                        Bathrooms = c.Int(),
                        Bedrooms = c.Int(),
                        SquareFeet = c.Int(),
                        Price = c.Int(),
                        Description = c.String(),
                        ImageName = c.String(maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Homes");
        }
    }
}
