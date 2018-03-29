using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.DAL.Entities;

namespace TextAnalyzer.DAL.EF
{
    public class AppDbContext: DbContext
    {
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RegularExpression> RegularExpressions { get; set; }
        public DbSet<Data> DataRecords { get; set; }
        public DbSet<AppliedRuleBlock> AppliedRuleBlocks { get; set; }
        public DbSet<AppliedRule> AppliedRules { get; set; }
        public DbSet<AppliedRuleResult> AppliedRuleResults { get; set; }
        
        public AppDbContext(string connectionString = "TextAnalyzerDbConnectionString")
            : base(connectionString)
        {
            Database.SetInitializer<AppDbContext>(new AppDbInitializer());
        }

        public AppDbContext(): base("TextAnalyzerDbConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rule>().HasMany(el => el.RegularExpressions).WithRequired(el => el.Rule).WillCascadeOnDelete(true);

            modelBuilder.Entity<Data>().HasMany(e => e.AppliedRuleBlocks).WithRequired(e => e.Data).WillCascadeOnDelete(true);
            modelBuilder.Entity<Rule>().HasMany(e => e.AppliedRules).WithRequired(e => e.Rule).WillCascadeOnDelete(false);

            modelBuilder.Entity<AppliedRuleBlock>().HasMany(e => e.AppliedRules).WithRequired(e => e.AppliedRuleBlock).WillCascadeOnDelete(true);
            modelBuilder.Entity<AppliedRule>().HasMany(e => e.AppliedRuleResults).WithRequired(e => e.AppliedRule).WillCascadeOnDelete(true);
        }
}

    public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext db)
        {
            var splitSentenceRule = new Rule
            {
                Title = "Split sentences",
                Description = "This rule splits blank text on sentences",
                CreatedAt = DateTime.Now,
                RegularExpressions = new List<RegularExpression>
                {
                    new RegularExpression {
                        CreatedAt = DateTime.Now,
                        RegExp = @"(?<=[.!?])\s+(?=[A-Z])"
                    }
                }
            };

            var filterQuestions = new Rule
            {
                Title = "Filter questions",
                Description = "This rule returns those sentences that are questions.",
                CreatedAt = DateTime.Now,
                RegularExpressions = new List<RegularExpression>
                {
                    new RegularExpression {
                        CreatedAt = DateTime.Now,
                        RegExp = @"[?]$"
                    }
                }
            };

            base.Seed(db);
        }
    }

}
