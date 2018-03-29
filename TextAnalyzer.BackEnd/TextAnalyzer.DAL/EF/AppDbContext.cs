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

            modelBuilder.Entity<Data>().HasMany(e => e.AppliedRules).WithRequired(e => e.Data).WillCascadeOnDelete(true);
            modelBuilder.Entity<Rule>().HasMany(e => e.AppliedRules).WithRequired(e => e.Rule).WillCascadeOnDelete(false);

            modelBuilder.Entity<AppliedRule>().HasMany(e => e.AppliedRuleResults).WithRequired(e => e.AppliedRule).WillCascadeOnDelete(true);
            modelBuilder.Entity<RegularExpression>().HasMany(e => e.AppliedRuleResults).WithRequired(e => e.RegularExpression).WillCascadeOnDelete(false);
        }
}

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext db)
        {
            //db.Phones.Add(new Phone { Name = "Nokia Lumia 630", Company = "Nokia", Price = 220 });
            //db.Phones.Add(new Phone { Name = "iPhone 6", Company = "Apple", Price = 320 });
            //db.Phones.Add(new Phone { Name = "LG G4", Company = "lG", Price = 260 });
            //db.Phones.Add(new Phone { Name = "Samsung Galaxy S 6", Company = "Samsung", Price = 300 });
            //db.SaveChanges();
        }
    }

}
