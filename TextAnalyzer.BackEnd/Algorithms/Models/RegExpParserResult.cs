using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using System.Collections.Generic;

namespace Algorithms.Models
{
    public class RegExpParserResult : IParserResult<RegExpRuleType>
    {
        public string RuleTitle { get; }
        public IParserResult<RegExpRuleType> ParentParserReult { get; }
        public string SourceText { get; }
        public IEnumerable<KeyValuePair<int, string>> Entries { get; }

        
        public RegExpParserResult(string sourceText, IEnumerable<KeyValuePair<int, string>> entries, 
            string ruleTitle = null, IParserResult<RegExpRuleType> parentParserReult = null)
        {
            RuleTitle = ruleTitle;
            SourceText = sourceText;
            Entries = entries;
            ParentParserReult = parentParserReult;
        }
    }
}
