namespace TextAnalyzer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppliedRuleBlocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DataId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Data", t => t.DataId, cascadeDelete: true)
                .Index(t => t.DataId);
            
            CreateTable(
                "dbo.AppliedRules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RuleId = c.Int(nullable: false),
                        AppliedRuleBlockId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        InnerConnectionType = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rules", t => t.RuleId)
                .ForeignKey("dbo.AppliedRuleBlocks", t => t.AppliedRuleBlockId, cascadeDelete: true)
                .Index(t => t.RuleId)
                .Index(t => t.AppliedRuleBlockId);
            
            CreateTable(
                "dbo.AppliedRuleResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppliedRuleId = c.Int(nullable: false),
                        IndexInText = c.Int(),
                        Value = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppliedRules", t => t.AppliedRuleId, cascadeDelete: true)
                .Index(t => t.AppliedRuleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppliedRuleBlocks", "DataId", "dbo.Data");
            DropForeignKey("dbo.AppliedRules", "AppliedRuleBlockId", "dbo.AppliedRuleBlocks");
            DropForeignKey("dbo.RegularExpressions", "RuleId", "dbo.Rules");
            DropForeignKey("dbo.AppliedRules", "RuleId", "dbo.Rules");
            DropForeignKey("dbo.AppliedRuleResults", "AppliedRuleId", "dbo.AppliedRules");
            DropIndex("dbo.RegularExpressions", new[] { "RuleId" });
            DropIndex("dbo.AppliedRuleResults", new[] { "AppliedRuleId" });
            DropIndex("dbo.AppliedRules", new[] { "AppliedRuleBlockId" });
            DropIndex("dbo.AppliedRules", new[] { "RuleId" });
            DropIndex("dbo.AppliedRuleBlocks", new[] { "DataId" });
            DropTable("dbo.Data");
            DropTable("dbo.RegularExpressions");
            DropTable("dbo.Rules");
            DropTable("dbo.AppliedRuleResults");
            DropTable("dbo.AppliedRules");
            DropTable("dbo.AppliedRuleBlocks");
        }
    }
}
