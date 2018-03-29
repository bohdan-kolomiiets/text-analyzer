namespace TextAnalyzer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Move_InnerConnectionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rules", "InnerConnectionType", c => c.Int(nullable: false));
            DropColumn("dbo.AppliedRules", "InnerConnectionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppliedRules", "InnerConnectionType", c => c.Int(nullable: false));
            DropColumn("dbo.Rules", "InnerConnectionType");
        }
    }
}
