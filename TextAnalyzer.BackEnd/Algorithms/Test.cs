using Algorithms.Models;
using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Rule;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Test
    {
        public Test()
        {
            string data = $"Ok, there are some important dates for us.\n " +
                $"First is 23-10-2002. The second two are: 23/11/2002 and 24/10/02. " +
                $"Do we have to watch crefully also these three: 10/23/2002, 23/11/2002 and 24/10/02? " +
                $"I believe some dates may mean nothing, for example: Oct 23,20002 and October 23, 2002. " +
                $"i think we all rule for participating. Was my brother born at 23 Oct 2002? Yes, mother at 23 October 2002. " +
                $"I think i have been ?outed. Isn't? it?";

            try
            {
                var splitSentences = new SingleRegExpRule(@"(?<=[.!?])\s+(?=[A-Z])", RuleType.RegExpSplit, "Split sentences");

                var filterQuestions = new SingleRegExpRule(@"[?]$", RuleType.RegExpMatches, "Filter quesions");

                var filterSentencesWithDate = new MultipleRegExpRules(new List<string>
                {
                    @"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}",
                    @"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}"
                }, RuleType.RegExpMatches, RulesConnectionType.Union, "Filter dates");

                var initData = new ParserResult(data, null);
                var result = initData.SplitByRegExp(splitSentences).FilterByRegExp(filterQuestions).FilterByRegExp(filterSentencesWithDate);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //var filterSentencesWithDate1 = new Rule(@"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}", 
            //    RuleType.RegExpMatches, 2, null, "Filter date (format 1)");
            //var filterSentencesWithDate2 = new Rule(@"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}",
            //    RuleType.RegExpMatches, 2, null, "Filter date (format 2)");


            //split
            Console.WriteLine("SPLITTED INTO SENTENCES");
            var split_senteces = Regex.Split(data, @"(?<=[.!?])\s+(?=[A-Z])");
            //var split_senteces = Regex.Matches(data, @"(?<=[.!?])\s+(?=[A-Z])");
            Console.WriteLine("Count: {0}", split_senteces.Length);
            for(int i= 0; i < split_senteces.Length; i++)
                Console.WriteLine("#{0}: {1}", i+1, split_senteces[i]);

            //filter by condition
            Console.WriteLine("QUESTIONS");
            var questions = split_senteces.Where(sentence => Regex.Match(sentence, @"[?]$").Success);
            foreach (var sentence in questions)
                Console.WriteLine(sentence);

            //filter by condition
            Console.WriteLine("QUESTIONS WITH DATES");
            //var datesReg1 = @"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}";
            //var datesReg2 = @"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}";
            var dateRegs = new List<string>();
            dateRegs.Add(@"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}");
            dateRegs.Add(@"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}");

            foreach (var sentence in questions)
            {
                foreach(var datesReg in dateRegs)
                {
                    var matches = Regex.Matches(sentence, datesReg);
                    if (matches.Count > 0)
                    {
                        Console.WriteLine("({0}) {1}", matches.Count, sentence);
                        foreach (Match match in matches)
                        {
                            Console.Write("value: {0}, index: {1} \n", match.Value, match.Index);
                        }
                    }
                }
            }

            //var questionsWithDates = questions.Where(sentence => Regex.Match(sentence, datesReg1).Success || Regex.Match(sentence, datesReg2).Success);
            //foreach (var sentence in questionsWithDates)
            //    Console.WriteLine(sentence);

/*
            //count
            Console.WriteLine("FIND WORD 'I'");
            var foundWords = Regex.Matches(data, @"[.,?!]?\s+I\s+");
            foreach (Match res in foundWords)
            {
                Console.WriteLine("value: {0}, index: {1}", res.Value, res.Index);
            }

            //calculate frequency of the word in text
            var words = data.Split(' ');
            float f = (float)foundWords.Count / words.Length * 100;
            Console.WriteLine("FREQUENCY: {0:0.00}%", f);
*/

            //take list of strings winth length>=1
            //iterate over list and look for matches => list of matches with index, match itselt, its lenths
            //1. total dates, total sentences with dates, print these sentences ordered by frequency.

/*
            //list entries
            Console.WriteLine("LIST ALL DATES");
            var datesReg1 = @"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}";
            var datesReg2 = @"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}";
            var datesRes1 = Regex.Matches(data, datesReg1);
            var datesRes2 = Regex.Matches(data, datesReg2);
            foreach(Match res in datesRes1)
                Console.WriteLine("value: {0}, index: {1}, length: {2}",  res.Value, res.Index, res.Length);
            foreach (Match res in datesRes2)
                Console.WriteLine("value: {0}, index: {1}, length: {2}", res.Value, res.Index, res.Length);
*/

            var blocks = new List<RulesBlock>();
            //blocks.Add(new RulesBlock(blocks.Count+1, ));
        }
    }
}
