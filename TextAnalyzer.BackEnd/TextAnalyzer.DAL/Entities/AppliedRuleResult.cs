using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.DAL.Entities
{
    public class AppliedRuleResult: EntryBaseModel
    {
        public int AppliedRuleId { get; set; }
        public virtual AppliedRule AppliedRule { get; set; }

        public int RegularExpressionId { get; set; }
        public virtual RegularExpression RegularExpression { get; set; }

        public string Result { get; set; }
    }
}
