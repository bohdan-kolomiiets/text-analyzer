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

        private int? _minMatchesNumber;
        private int? _maxMatchesNumber;

        public int? MinMatchesNumber
        {
            get { return _minMatchesNumber; }
            private set { _minMatchesNumber = value.HasValue ? value.Value >= 0 ? value : 0 : null; }
        }
        public int? MAxMatchesNumber
        {
            get { return _maxMatchesNumber; }
            private set { _maxMatchesNumber = value.HasValue ? value.Value >= 0 ? value : int.MaxValue : null; }
        }

        public RegExpRule(RuleType ruleType, string title = "",
            int? minMatchesNumber = null, int? maxMatchesNumber = null)
        {
            RuleType = ruleType;
            Title = title;

            if (ruleType == RuleType.RegExpFilter)
            {
                if (minMatchesNumber.HasValue && maxMatchesNumber.HasValue)
                {
                    if (minMatchesNumber <= maxMatchesNumber)
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
