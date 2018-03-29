using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Rule
{
    public class SingleRegExpRule : RegExpRule
    {
        public string RegularExpression { get; }

        public SingleRegExpRule(string regularExpression, RuleType ruleType, string title = "")
            :base(ruleType, title)
        {
            RegularExpression = regularExpression;
        }

        public SingleRegExpRule(string regularExpression, RuleType ruleType, 
            int? minMatchesNumber = null, int? maxMatchesNumber = null, string title = "")
            :base(ruleType, title, minMatchesNumber, maxMatchesNumber)
        {
            RegularExpression = regularExpression;
        }
    }
}
