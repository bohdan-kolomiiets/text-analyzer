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
        private int? _minMatchesNumber;
        private int? _maxMatchesNumber;

        public int? MinMatchesNumber {
            get { return _minMatchesNumber; }
            private set { _minMatchesNumber = value.HasValue ? value.Value >= 0 ? value : 0 : null; }
        }
        public int? MAxMatchesNumber { get { return _maxMatchesNumber; }
            private set { _maxMatchesNumber = value.HasValue ? value.Value >= 0 ? value : int.MaxValue : null; }
        }

        public MultipleRegExpRules(IEnumerable<string> regularExpressions, RuleType ruleType, 
            RulesConnectionType connectionType, string title = "")
            : base(ruleType, title)
        {
            RegularExpressions = regularExpressions;
            ConnectionType = connectionType;
        }

        public MultipleRegExpRules(IEnumerable<string> regularExpressions, RuleType ruleType, 
            RulesConnectionType connectionType, int? minMatchesNumber = null, int? maxMatchesNumber = null, string title = "")
            :base(ruleType, title)
        {
            RegularExpressions = regularExpressions;
            ConnectionType = connectionType;

            if (ruleType == RuleType.RegExpMatches)
            {
                if(minMatchesNumber.HasValue && maxMatchesNumber.HasValue)
                {
                    if(minMatchesNumber <= maxMatchesNumber)
                    {
                        MinMatchesNumber = minMatchesNumber;
                        MAxMatchesNumber = maxMatchesNumber;
                    }
                    else
                    {
                        MinMatchesNumber = maxMatchesNumber;
                        MAxMatchesNumber = minMatchesNumber;
                    }
                }
            }
        }
    }
}
