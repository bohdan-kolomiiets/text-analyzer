using Algorithms.Models;
using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using Algorithms.Models.Rule;
using Algorithms.RegExpParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Algorithms.RegExpParser
{
    public static class RegExpFinderExtension
    {
        public static RegExpParserResult FindByRegExp(this RegExpParserResult prevParserResult, 
            RegExpRule rule, IRegExpParserResultPublisher<RegExpRuleType, RegExpParserResultEventArgs> resultPublisher)
        {
            //check if regular expression type matches operation type
            if (rule.RuleType != RegExpRuleType.RegExpFind)
                throw new NotSupportedException(
                    String.Format("Method accepts regular expressions that are aimed to filter text, but this has type {0}",
                    rule.RuleType.ToString()));

            //check if entires are not null as next calculations are based on it
            if (prevParserResult.Entries == null)
                throw new ArgumentNullException("Something went wrong. Entries of previous action are null.");

            //apply different filtration logic depending on type of rule
            IEnumerable<KeyValuePair<int, string>> entryIndexDictionary = new List<KeyValuePair<int, string>>();
            if (rule is SingleRegExpRule)
                entryIndexDictionary = FindEntriesWithSingleRexExp(prevParserResult.Entries, (rule as SingleRegExpRule));
            else if (rule is MultipleRegExpRules)
                entryIndexDictionary = FindEntriesWithMultipleRegExp(prevParserResult.Entries, (rule as MultipleRegExpRules));
            else
                throw new NotSupportedException("Passed rule type is not supported in this method.");

            resultPublisher.RegExpParserResult = new RegExpParserResult(
                (prevParserResult.Entries != null && prevParserResult.Entries.Count() != 0) ?
                String.Join("\n", prevParserResult.Entries.Select(e => e.Value)) : prevParserResult.SourceText,
                entryIndexDictionary, rule.Title, prevParserResult);
            resultPublisher.Publish();
            return (RegExpParserResult)resultPublisher.RegExpParserResult;
        }

        private static IEnumerable<KeyValuePair<int, string>> FindEntriesWithSingleRexExp(IEnumerable<KeyValuePair<int, string>> entries, SingleRegExpRule singleRule)
        {
            var findRes = new List<KeyValuePair<int, string>>();
            foreach (var entry in entries)
            {
                var matchRes = Regex.Matches(entry.Value, singleRule.RegularExpression);
                foreach (Match match in matchRes)
                    findRes.Add(new KeyValuePair<int, string>(match.Index, match.Value));
            }
            return findRes;
        }

        private static IEnumerable<KeyValuePair<int, string>> FindEntriesWithMultipleRegExp(IEnumerable<KeyValuePair<int, string>> entries, MultipleRegExpRules multipleRules)
        {
            var findRes = new List<KeyValuePair<int, string>>();
            foreach (var entry in entries)
            {
                foreach (var regExp in multipleRules.RegularExpressions)
                {
                    var matchRes = Regex.Matches(entry.Value, regExp);
                    foreach (Match match in matchRes)
                        findRes.Add(new KeyValuePair<int, string>(match.Index, match.Value));
                }
                if (multipleRules.ConnectionType == RulesConnectionType.Intersection)//filter only matches that repeat
                    findRes = GetEntriesThatRepeat(findRes);
            }
            return findRes;
        }

        private static List<KeyValuePair<int, string>> GetEntriesThatRepeat(IEnumerable<KeyValuePair<int, string>> entries)
        {
            var entriesList = entries.ToList();
            var repeated = new List<KeyValuePair<int, string>>();

            foreach (var item in entriesList)
            {
                var repetitionItems = entriesList.Where(x => x.Key == item.Key && x.Value == item.Value).ToList();
                if (repetitionItems.Count > 1)
                    repeated.Add(new KeyValuePair<int, string>(item.Key, item.Value));
                foreach (var repeatItem in repetitionItems)
                    entriesList.Remove(repeatItem);
            }
            return repeated;
        }

    }
}
