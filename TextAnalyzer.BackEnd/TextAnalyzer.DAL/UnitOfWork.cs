using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.DAL.EF;
using TextAnalyzer.DAL.Entities;
using TextAnalyzer.DAL.Interfaces;
using TextAnalyzer.DAL.Repositories;

namespace TextAnalyzer.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext db;

        private IRepository<Rule> _Rules;
        private IRepository<RegularExpression> _RegularExpressions;
        private IRepository<Data> _DataRecords;
        private IRepository<AppliedRule> _AppliedRules;
        private IRepository<AppliedRuleResult> _AppliedRuleResults;

        public UnitOfWork(AppDbContext context)
        {
            this.db = context;
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IRepository<Rule> Rules
        {
            get
            {
                if (_Rules == null)
                    _Rules = new Repository<Rule>(db);
                return _Rules;
            }
        }

        public IRepository<RegularExpression> RegularExpressions
        {
            get
            {
                if (_RegularExpressions == null)
                    _RegularExpressions = new Repository<RegularExpression>(db);
                return _RegularExpressions;
            }
        }

        public IRepository<Data> DataRecords
        {
            get
            {
                if (_DataRecords == null)
                    _DataRecords = new Repository<Data>(db);
                return _DataRecords;
            }
        }

        public IRepository<AppliedRule> AppliedRules
        {
            get
            {
                if (_AppliedRules == null)
                    _AppliedRules = new Repository<AppliedRule>(db);
                return _AppliedRules;
            }
        }

        public IRepository<AppliedRuleResult> AppliedRuleResults
        {
            get
            {
                if (_AppliedRuleResults == null)
                    _AppliedRuleResults = new Repository<AppliedRuleResult>(db);
                return _AppliedRuleResults;
            }
        }

    }
}
