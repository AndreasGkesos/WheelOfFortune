namespace WheelOfFortune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorandandnewDomains : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Balances", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Coupons", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Spins", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Coupons", new[] { "User_Id" });
            DropPrimaryKey("dbo.AspNetUserRoles");
            CreateTable(
                "dbo.CouponValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WheelConfigurationSlice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Propability = c.Double(nullable: false),
                        Type = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Win = c.Boolean(nullable: false),
                        ResultText = c.String(nullable: false),
                        Score = c.Double(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.WheelConfigurationSliceWheelConfigurations",
                c => new
                    {
                        WheelConfigurationSlice_Id = c.Int(nullable: false),
                        WheelConfiguration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WheelConfigurationSlice_Id, t.WheelConfiguration_Id })
                .ForeignKey("dbo.WheelConfigurationSlice", t => t.WheelConfigurationSlice_Id, cascadeDelete: true)
                .ForeignKey("dbo.WheelConfigurations", t => t.WheelConfiguration_Id, cascadeDelete: true)
                .Index(t => t.WheelConfigurationSlice_Id)
                .Index(t => t.WheelConfiguration_Id);
            
            AddColumn("dbo.Coupons", "Value_Id", c => c.Int(nullable: false));
            AddColumn("dbo.WheelConfigurations", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.WheelConfigurations", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Transactions", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Coupons", "User_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "RoleId", "UserId" });
            CreateIndex("dbo.Coupons", "User_Id");
            CreateIndex("dbo.Coupons", "Value_Id");
            CreateIndex("dbo.WheelConfigurations", "User_Id");
            AddForeignKey("dbo.Coupons", "Value_Id", "dbo.CouponValues", "Id");
            AddForeignKey("dbo.WheelConfigurations", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Balances", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Coupons", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.Spins", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Coupons", "Value");
            DropColumn("dbo.WheelConfigurations", "Propability");
            DropColumn("dbo.WheelConfigurations", "Type");
            DropColumn("dbo.WheelConfigurations", "Value");
            DropColumn("dbo.WheelConfigurations", "Win");
            DropColumn("dbo.WheelConfigurations", "ResultText");
            DropColumn("dbo.WheelConfigurations", "Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WheelConfigurations", "Score", c => c.Double(nullable: false));
            AddColumn("dbo.WheelConfigurations", "ResultText", c => c.String(nullable: false));
            AddColumn("dbo.WheelConfigurations", "Win", c => c.Boolean(nullable: false));
            AddColumn("dbo.WheelConfigurations", "Value", c => c.String(nullable: false));
            AddColumn("dbo.WheelConfigurations", "Type", c => c.String(nullable: false));
            AddColumn("dbo.WheelConfigurations", "Propability", c => c.Double(nullable: false));
            AddColumn("dbo.Coupons", "Value", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Spins", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Coupons", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Balances", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WheelConfigurations", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfiguration_Id", "dbo.WheelConfigurations");
            DropForeignKey("dbo.WheelConfigurationSliceWheelConfigurations", "WheelConfigurationSlice_Id", "dbo.WheelConfigurationSlice");
            DropForeignKey("dbo.WheelConfigurationSlice", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Coupons", "Value_Id", "dbo.CouponValues");
            DropIndex("dbo.WheelConfigurationSliceWheelConfigurations", new[] { "WheelConfiguration_Id" });
            DropIndex("dbo.WheelConfigurationSliceWheelConfigurations", new[] { "WheelConfigurationSlice_Id" });
            DropIndex("dbo.WheelConfigurationSlice", new[] { "User_Id" });
            DropIndex("dbo.WheelConfigurations", new[] { "User_Id" });
            DropIndex("dbo.Coupons", new[] { "Value_Id" });
            DropIndex("dbo.Coupons", new[] { "User_Id" });
            DropPrimaryKey("dbo.AspNetUserRoles");
            AlterColumn("dbo.Coupons", "User_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Transactions", "Type");
            DropColumn("dbo.WheelConfigurations", "User_Id");
            DropColumn("dbo.WheelConfigurations", "DateCreated");
            DropColumn("dbo.Coupons", "Value_Id");
            DropTable("dbo.WheelConfigurationSliceWheelConfigurations");
            DropTable("dbo.WheelConfigurationSlice");
            DropTable("dbo.CouponValues");
            AddPrimaryKey("dbo.AspNetUserRoles", new[] { "UserId", "RoleId" });
            CreateIndex("dbo.Coupons", "User_Id");
            AddForeignKey("dbo.Transactions", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Spins", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Coupons", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Balances", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
