using Algorithms.Models;
using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using Algorithms.Models.Rule;
using Algorithms.RegExpParser.Interfaces;
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
        public static RegExpParserResult SplitByRegExp(this RegExpParserResult prevParserResult, 
            SingleRegExpRule rule, IRegExpParserResultPublisher<RegExpRuleType, RegExpParserResultEventArgs> resultPublisher)
        {
            //check if regular expression type matches operation type
            if (rule.RuleType != RegExpRuleType.RegExpSplit)
                throw new NotSupportedException(
                    String.Format("Method accepts regular expressions that are aimed to split text, but this has type {0}",
                    rule.RuleType.ToString()));

            //split blank text
            var entryArray = Regex.Split(prevParserResult.SourceText, rule.RegularExpression);

            //identify entries indexes
            var entryIndexDictionary = new List<KeyValuePair<int, string>>();
            foreach (var entry in entryArray)
            {
                int entryIndex = prevParserResult.SourceText.IndexOf(entry);
                entryIndexDictionary.Add(new KeyValuePair<int, string>(entryIndex, entry));
            }

            resultPublisher.RegExpParserResult = new RegExpParserResult(
                (prevParserResult.Entries != null && prevParserResult.Entries.Count() != 0) ?
                String.Join("\n", prevParserResult.Entries.Select(e => e.Value)) : prevParserResult.SourceText,
                entryIndexDictionary, rule.Title, prevParserResult);
            resultPublisher.Publish();
            return (RegExpParserResult)resultPublisher.RegExpParserResult;
        }

    }
}
