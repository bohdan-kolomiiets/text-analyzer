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
    public static class RegExFilterExtension
    {
        public static RegExpParserResult FilterByRegExp(this RegExpParserResult prevParserResult, 
            RegExpRule rule, IRegExpParserResultPublisher<RegExpRuleType, RegExpParserResultEventArgs> resultPublisher)
        {
            //check if regular expression type matches operation type
            if (rule.RuleType != RegExpRuleType.RegExpFilter)
                throw new NotSupportedException(
                    String.Format("Method accepts regular expressions that are aimed to filter text, but this has type {0}",
                    rule.RuleType.ToString()));

            //check if entires are not null as next calculations are based on it
            if (prevParserResult.Entries == null)
                throw new ArgumentNullException("Something went wrong. Entries of previous action are null.");

            //apply different filtration logic depending on type of rule
            IEnumerable<KeyValuePair<int, string>> entryIndexDictionary = new List<KeyValuePair<int, string>>();
            if (rule is SingleRegExpRule)
                entryIndexDictionary = FilerEntriesWithSingleRexExp(prevParserResult.Entries, (rule as SingleRegExpRule));
            else if (rule is MultipleRegExpRules)
                entryIndexDictionary = FilterEntriesWithMultipleRegExp(prevParserResult.Entries, (rule as MultipleRegExpRules));
            else
                throw new NotSupportedException("Passed rule type is not supported in this method.");

            resultPublisher.RegExpParserResult = new RegExpParserResult(
                (prevParserResult.Entries != null && prevParserResult.Entries.Count() != 0) ? 
                String.Join("\n", prevParserResult.Entries.Select(e => e.Value)) : prevParserResult.SourceText, 
                entryIndexDictionary, rule.Title, prevParserResult);
            resultPublisher.Publish();
            return (RegExpParserResult)resultPublisher.RegExpParserResult;
        }

        private static IEnumerable<KeyValuePair<int, string>> FilerEntriesWithSingleRexExp(IEnumerable<KeyValuePair<int, string>> entries, SingleRegExpRule singleRule)
        {
            var filteredRes = new List<KeyValuePair<int, string>>();
            foreach (var entry in entries)
            {
                var matchRes = Regex.Matches(entry.Value, singleRule.RegularExpression);
                if (matchRes.Count == 0)
                    continue;
                else if (singleRule.MinMatchesNumber.HasValue && singleRule.MinMatchesNumber.Value > matchRes.Count)
                    continue;
                else if (singleRule.MAxMatchesNumber.HasValue && singleRule.MAxMatchesNumber.Value < matchRes.Count)
                    continue;
                else
                    filteredRes.Add(new KeyValuePair<int, string>(entry.Key, entry.Value));
            }
            return filteredRes;
        }

        private static IEnumerable<KeyValuePair<int, string>> FilterEntriesWithMultipleRegExp(IEnumerable<KeyValuePair<int, string>> entries, MultipleRegExpRules multipleRules)
        {
            var filteredRes = new List<KeyValuePair<int, string>>();
            foreach (var entry in entries)
            {
                var resultVector = new List<bool>();
                foreach (var regExp in multipleRules.RegularExpressions)
                {
                    var matchRes = Regex.Matches(entry.Value, regExp);
                    if (matchRes.Count == 0)
                        resultVector.Add(false);
                    else if (multipleRules.MinMatchesNumber.HasValue && multipleRules.MinMatchesNumber.Value > matchRes.Count)
                        resultVector.Add(false);
                    else if (multipleRules.MAxMatchesNumber.HasValue && multipleRules.MAxMatchesNumber.Value < matchRes.Count)
                        resultVector.Add(false);
                    else
                        resultVector.Add(true);
                }
                if ((multipleRules.ConnectionType == RulesConnectionType.Union && resultVector.Where(x => x).Count() >= 1)
                    || (multipleRules.ConnectionType == RulesConnectionType.Intersection && resultVector.Where(x => x).Count() == multipleRules.RegularExpressions.Count()))
                    filteredRes.Add(new KeyValuePair<int, string>(entry.Key, entry.Value));
            }
            return filteredRes;
        }

    }
}
