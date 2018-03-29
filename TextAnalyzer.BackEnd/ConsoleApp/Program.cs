using Algorithms;
using Algorithms.Models;
using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Rule;
using Algorithms.RegExpParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = File.ReadAllText("Data.txt");

            //var splitSentences = new SingleRegExpRule(@"(?<=[.!?])\s+(?=[A-Z])", RuleType.RegExpSplit, "Split sentences");

            //var filterQuestions = new SingleRegExpRule(@"[?]$", RuleType.RegExpFilter, "Filter quesions");

            //var filterSentencesWithDate = new MultipleRegExpRules(new List<string>
            //    {
            //        @"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}",
            //        @"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}"
            //    }, RuleType.RegExpFilter, RulesConnectionType.Union, "Filter dates");

            //var initData = new ParserResult(data, null);
            //var result = initData.SplitByRegExp(splitSentences).FilterByRegExp(filterQuestions).FilterByRegExp(filterSentencesWithDate);

            Console.WriteLine("INITIAL TEXT:\n{0}", data);

            //var freq = SimpleRexExpForTest.CalcFrequencyOfWordI(data);
            var sentences = SimpleRexExpForTest.SplitOnSentences(data, true);
            var questions = SimpleRexExpForTest.FilterQuestions(sentences, true);
            SimpleRexExpForTest.FilterWithDates(questions, true);
        }
    }
}
