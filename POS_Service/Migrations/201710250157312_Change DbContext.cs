namespace POS_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChosenProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        guid = c.String(),
                        productId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        productName = c.String(),
                        productPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        FnNumber = c.String(nullable: false),
                        CustomerType = c.Int(nullable: false),
                        guid = c.String(),
                        IsDeliveried = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogInDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fName = c.String(nullable: false),
                        lName = c.String(nullable: false),
                        dateOfBrt = c.DateTime(nullable: false),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        cfmPass = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        designation = c.String(nullable: false),
                        isGradute = c.Boolean(nullable: false),
                        address = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductQuantity = c.Int(nullable: false),
                        ProductImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockDatas");
            DropTable("dbo.LogInDatas");
            DropTable("dbo.CustomerDatas");
            DropTable("dbo.ChosenProducts");
        }
    }
}
