using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms.Models;
using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Rule;
using Algorithms.RegExpParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class FilteringRulesTests
    {
        public string _data;
        public FilteringRulesTests()
        {
            _data = File.ReadAllText("Data.txt");
        }

        [TestMethod]
        public void SplitByRegExp_WithSingleRegExpRule_Split9Sentences()
        {
            //Arrange
            var splitSentences = new SingleRegExpRule(@"(?<=[.!?])\s+(?=[A-Z])", RuleType.RegExpSplit, "Split sentences");
            var initData = new ParserResult(_data, null);

            //Act
            var sentences = initData.SplitByRegExp(splitSentences);

            //Assert
            Assert.IsTrue(sentences.Entries.ToList().Count == 9);
        }

        [TestMethod]
        public void ChainOfSplitByRegExpAndFilterByRegExp_WithSingleRegExpRule_Split9SentencesAdnFiltersQuestions()
        {
            //Arrange
            var splitSentences = new SingleRegExpRule(@"(?<=[.!?])\s+(?=[A-Z])", RuleType.RegExpSplit, "Split sentences");
            var filterQuestions = new SingleRegExpRule(@"[?]$", RuleType.RegExpFilter, "Filter quesions");
            var initData = new ParserResult(_data, null);

            //Act
            var questions = initData.SplitByRegExp(splitSentences).FilterByRegExp(filterQuestions);

            //Assert
            Assert.IsTrue(questions.Entries.ToList().Count == 3);
        }

        [TestMethod]
        public void ChainOfSplitByRegExpAndFilterByRegExp_WithMultipleRegExpRule_Split9SentencesAdnFiltersSentencesWithDates()
        {
            //Arrange
            var splitSentences = new SingleRegExpRule(@"(?<=[.!?])\s+(?=[A-Z])", RuleType.RegExpSplit, "Split sentences");
            var filterSentencesWithDate = new MultipleRegExpRules(new List<string>
                {
                    @"\d{1,2}[/-]\d{1,2}[/-]\d{2,4}",
                    @"(?:\d{1,2} )?(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)[a-z]* (?:\d{1,2}, )?\d{4}"
                }, RuleType.RegExpSplit, RulesConnectionType.Union, "Filter dates");
            var initData = new ParserResult(_data, null);

            //Act
            var sentencesWithBothFormsOfDates = initData.SplitByRegExp(splitSentences).FilterByRegExp(filterSentencesWithDate);

            //Assert
            Assert.IsTrue(sentencesWithBothFormsOfDates.Entries.ToList().Count == 6);
        }


    }
}
