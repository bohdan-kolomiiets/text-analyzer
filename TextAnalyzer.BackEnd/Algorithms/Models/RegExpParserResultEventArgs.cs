using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class RegExpParserResultEventArgs : EventArgs
    {
        public IParserResult<RegExpRuleType> RegExpParserResult { get; }

        public RegExpParserResultEventArgs(IParserResult<RegExpRuleType> regExpParserResult)
        {
            RegExpParserResult = regExpParserResult;
        }
    }
}
