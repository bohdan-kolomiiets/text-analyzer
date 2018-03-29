using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms.RegExpParser
{
    public static class SimpleRexExpForTest
    {

        public static IEnumerable<string> SplitOnSentences(string data, bool print)
        {
            var senteces = Regex.Split(data, @"(?<=[.!?])\s+(?=[A-Z])");

            if(print)
            {
                Console.WriteLine("SPLITTED INTO SENTENCES");
                Console.WriteLine("Count: {0}", senteces.Length);
                for (int i = 0; i < senteces.Length; i++)
                    Console.WriteLine("#{0}: {1}", i + 1, senteces[i]);
            }

            return senteces;
        }

        public static IEnumerable<string> FilterQuestions(IEnumerable<string> senteces, bool print)
        {
            var questions = senteces.Where(sentence => Regex.Match(sentence, @"[?]$").Success);

            if (print)
            {
                Console.WriteLine("QUESTIONS");
                foreach (var sentence in questions)
                    Console.WriteLine(sentence);
            }

            return questions;
        }

        public static void FilterWithDates(IEnumerable<string> sentences, bool print)
        {
            var dateRegs = new List<string>();
            dateRegs.Add(@"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}");
            dateRegs.Add(@"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}");

            Console.WriteLine("QUESTIONS WITH DATES");
            foreach (var sentence in sentences)
            {
                foreach (var datesReg in dateRegs)
                {
                    var matches = Regex.Matches(sentence, datesReg);
                    if (matches.Count > 0)
                    {
                        if(print)
                            Console.WriteLine("({0}) {1}", matches.Count, sentence);
                        if(print)
                            foreach (Match match in matches)
                                Console.Write("value: {0}, index: {1} \n", match.Value, match.Index);
                    }
                }
            }
        }

        public static float CalcFrequencyOfWordI(string data)
        {
            Console.WriteLine("FIND WORD 'I'");
            var foundWords = Regex.Matches(data, @"[.,?!]?\s+I\s+");
            foreach (Match res in foundWords)
            {
                Console.WriteLine("value: {0}, index: {1}", res.Value, res.Index);
            }

            var words = data.Split(' ');
            float f = (float)foundWords.Count / words.Length * 100;
            Console.WriteLine("FREQUENCY: {0:0.00}%", f);

            return f;
        }
    }
}
