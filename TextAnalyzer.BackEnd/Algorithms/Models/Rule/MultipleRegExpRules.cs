using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Rule
{
    public class MultipleRegExpRules: RegExpRule
    {
        public IEnumerable<string> RegularExpressions { get; }
        public RulesConnectionType ConnectionType { get; set; }


        public MultipleRegExpRules(IEnumerable<string> regularExpressions, RegExpRuleType ruleType, 
            RulesConnectionType connectionType, string title = "")
            : base(ruleType, title)
        {
            RegularExpressions = regularExpressions;
            ConnectionType = connectionType;
        }

        public MultipleRegExpRules(IEnumerable<string> regularExpressions, RegExpRuleType ruleType, 
            RulesConnectionType connectionType, int? minMatchesNumber = null, int? maxMatchesNumber = null, string title = "")
            :base(ruleType, title, minMatchesNumber, maxMatchesNumber)
        {
            RegularExpressions = regularExpressions;
            ConnectionType = connectionType;
        }
    }
}
