using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.DAL.Entities
{
    public class RegularExpression: EntryBaseModel
    {
        public virtual Rule Rule { get; set; }
        public int RuleId { get; set; }

        public virtual ICollection<AppliedRuleResult> AppliedRuleResults { get; set; } = new Collection<AppliedRuleResult>();
        
        public string RegExp { get; set; }

    }
}
