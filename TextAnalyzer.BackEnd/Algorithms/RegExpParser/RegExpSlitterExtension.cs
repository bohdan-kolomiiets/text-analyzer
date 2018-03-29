using Algorithms.Models;
using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms.RegExpParser
{
    public static class RegExpSlitterExtension
    {

        public static ParserResult SplitByRegExp(this ParserResult prevParserResult, SingleRegExpRule rule)
        {
            //check if regular expression type matches operation type
            if (rule.RuleType != RuleType.RegExpSplit)
                throw new NotSupportedException(
                    String.Format("Method accepts regular expressions that are aimed to split text, but this has type {0}",
                    rule.RuleType.ToString()));

            //split blank text
            var entryArray = Regex.Split(prevParserResult.SourseText, rule.RegularExpression);

            //identify entries indexes
            var entryIndexDictionary = new List<KeyValuePair<int, string>>();
            foreach (var entry in entryArray)
            {
                int entryIndex = prevParserResult.SourseText.IndexOf(entry);
                entryIndexDictionary.Add(new KeyValuePair<int, string>(entryIndex, entry));
            }

            return new ParserResult(prevParserResult.SourseText, entryIndexDictionary, prevParserResult);
        }

    }
}
