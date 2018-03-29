using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalyzer.DAL.Entities;

namespace TextAnalyzer.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Rule> Rules { get; }
        IRepository<RegularExpression> RegularExpressions { get; }
        IRepository<Data> DataRecords { get; }
        IRepository<AppliedRule> AppliedRules { get; }
        IRepository<AppliedRuleResult> AppliedRuleResults { get; }

        int SaveChanges();
    }
}
