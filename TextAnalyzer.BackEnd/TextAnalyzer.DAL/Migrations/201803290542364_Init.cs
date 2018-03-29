namespace TextAnalyzer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppliedRuleResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppliedRuleId = c.Int(nullable: false),
                        RegularExpressionId = c.Int(nullable: false),
                        Result = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppliedRules", t => t.AppliedRuleId, cascadeDelete: true)
                .ForeignKey("dbo.RegularExpressions", t => t.RegularExpressionId)
                .Index(t => t.AppliedRuleId)
                .Index(t => t.RegularExpressionId);
            
            CreateTable(
                "dbo.AppliedRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataId = c.Int(nullable: false),
                        RuleId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data", t => t.DataId, cascadeDelete: true)
                .ForeignKey("dbo.Rules", t => t.RuleId)
                .Index(t => t.DataId)
                .Index(t => t.RuleId);
            
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DataValue = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        MinMatchesNumber = c.Int(),
                        MaxMatchesNumber = c.Int(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegularExpressions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RuleId = c.Int(nullable: false),
                        RegExp = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rules", t => t.RuleId, cascadeDelete: true)
                .Index(t => t.RuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegularExpressions", "RuleId", "dbo.Rules");
            DropForeignKey("dbo.AppliedRuleResults", "RegularExpressionId", "dbo.RegularExpressions");
            DropForeignKey("dbo.AppliedRules", "RuleId", "dbo.Rules");
            DropForeignKey("dbo.AppliedRules", "DataId", "dbo.Data");
            DropForeignKey("dbo.AppliedRuleResults", "AppliedRuleId", "dbo.AppliedRules");
            DropIndex("dbo.RegularExpressions", new[] { "RuleId" });
            DropIndex("dbo.AppliedRules", new[] { "RuleId" });
            DropIndex("dbo.AppliedRules", new[] { "DataId" });
            DropIndex("dbo.AppliedRuleResults", new[] { "RegularExpressionId" });
            DropIndex("dbo.AppliedRuleResults", new[] { "AppliedRuleId" });
            DropTable("dbo.RegularExpressions");
            DropTable("dbo.Rules");
            DropTable("dbo.Data");
            DropTable("dbo.AppliedRules");
            DropTable("dbo.AppliedRuleResults");
        }
    }
}
