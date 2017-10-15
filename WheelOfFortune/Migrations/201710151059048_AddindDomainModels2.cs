namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddindDomainModels2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BalanceValue = c.Long(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Value = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateExpired = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Spins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScoreValue = c.Double(nullable: false),
                        BetValue = c.Double(nullable: false),
                        ResultValue = c.Double(nullable: false),
                        ExecutionDate = c.DateTime(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.WheelConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Propability = c.Double(nullable: false),
                        Type = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Win = c.Boolean(nullable: false),
                        ResultText = c.String(nullable: false),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.WheelConfigurationSpins",
                c => new
                    {
                        WheelConfiguration_Id = c.Int(nullable: false),
                        Spin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WheelConfiguration_Id, t.Spin_Id })
                .ForeignKey("dbo.WheelConfigurations", t => t.WheelConfiguration_Id, cascadeDelete: true)
                .ForeignKey("dbo.Spins", t => t.Spin_Id, cascadeDelete: true)
                .Index(t => t.WheelConfiguration_Id)
                .Index(t => t.Spin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WheelConfigurationSpins", "Spin_Id", "dbo.Spins");
            DropForeignKey("dbo.WheelConfigurationSpins", "WheelConfiguration_Id", "dbo.WheelConfigurations");
            DropForeignKey("dbo.Spins", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Coupons", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Balances", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WheelConfigurationSpins", new[] { "Spin_Id" });
            DropIndex("dbo.WheelConfigurationSpins", new[] { "WheelConfiguration_Id" });
            DropIndex("dbo.Transactions", new[] { "User_Id" });
            DropIndex("dbo.Spins", new[] { "User_Id" });
            DropIndex("dbo.Coupons", new[] { "User_Id" });
            DropIndex("dbo.Balances", new[] { "User_Id" });
            DropTable("dbo.WheelConfigurationSpins");
            DropTable("dbo.Transactions");
            DropTable("dbo.WheelConfigurations");
            DropTable("dbo.Spins");
            DropTable("dbo.Coupons");
            DropTable("dbo.Balances");
        }
    }
}
