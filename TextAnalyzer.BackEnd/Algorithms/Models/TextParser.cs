using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using Algorithms.Models.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public static class TextParser// : ITextParser
    {
        static TextParser()
        {
        }
        

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
            var entryIndexDictionary = new Dictionary<int, string>();
            foreach(var entry in entryArray)
            {
                int entryIndex = prevParserResult.SourseText.IndexOf(entry);
                entryIndexDictionary.Add(entryIndex, entry);
            }

            return new ParserResult(prevParserResult.SourseText, entryIndexDictionary, prevParserResult);
        }

        //public static ParserResult FindByRegExp(this )


        public static ParserResult FilterByRegExp(this ParserResult prevParserResult, RegExpRule rule)
        {
            //check if regular expression type matches operation type
            if (rule.RuleType != RuleType.RegExpMatches)
                throw new NotSupportedException(
                    String.Format("Method accepts regular expressions that are aimed to filter text, but this has type {0}",
                    rule.RuleType.ToString()));

            //check if entires are not null as next calculations are based on it
            if (prevParserResult.Entries == null)
                throw new ArgumentNullException("Something went wrong. Entries of previous action are null.");

            //apply different filtration logic depending on type of rule
            IDictionary<int, string>  entryIndexDictionary = new Dictionary<int, string>();
            if (rule is SingleRegExpRule)
                entryIndexDictionary = FilerEntriesWithSingleRexExp(prevParserResult.Entries, (rule as SingleRegExpRule));
            else if (rule is MultipleRegExpRules)
                entryIndexDictionary = FilterEntriesWithMultipleRegExp(prevParserResult.Entries, (rule as MultipleRegExpRules));
            else
                throw new NotSupportedException("Passed rule type is not supported in this method.");

            return new ParserResult(String.Join("\n", prevParserResult.Entries), entryIndexDictionary, prevParserResult);
        }

        private static IDictionary<int, string> FilerEntriesWithSingleRexExp(IDictionary<int, string> entries, SingleRegExpRule singleRule)
        {
            var filteredRes = new Dictionary<int, string>();
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
                    filteredRes.Add(entry.Key, entry.Value);
            }
            return filteredRes;
        }

        private static IDictionary<int, string> FilterEntriesWithMultipleRegExp(IDictionary<int, string> entries, MultipleRegExpRules multipleRules)
        {
            var filteredRes = new Dictionary<int, string>();
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
                    filteredRes.Add(entry.Key, entry.Value);
            }
            return filteredRes;
        }

    }
}
