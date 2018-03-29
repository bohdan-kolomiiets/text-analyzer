using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using Algorithms.Models.Interfaces.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class ParserResult : IParserResult<RuleType>
    {
        public IParserResult<RuleType> ParentParserReult { get; }
        public string SourseText { get; }
        public IEnumerable<KeyValuePair<int, string>> Entries { get; }

        public ParserResult(string sourceText, IEnumerable<KeyValuePair<int, string>> entries, IParserResult<RuleType> parentParserReult = null)
        {
            SourseText = sourceText;
            Entries = entries;
            ParentParserReult = parentParserReult;
        }
    }
}
