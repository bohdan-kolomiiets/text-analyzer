using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using Algorithms.Models.Interfaces.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Rule
{
    public abstract class RegExpRule: IRegExpRule<RuleType>
    {
        public string Title { get; }

        public RuleType RuleType { get; }

        public RegExpRule(RuleType ruleType, string title = "")
        {
            RuleType = ruleType;
            Title = title;
        }
    }
}
