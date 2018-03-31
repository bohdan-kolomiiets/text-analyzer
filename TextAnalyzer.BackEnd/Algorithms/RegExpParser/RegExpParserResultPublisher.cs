using Algorithms.Models;
using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using Algorithms.RegExpParser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.RegExpParser
{
    public class RegExpParserResultPublisher: IRegExpParserResultPublisher<RegExpRuleType, RegExpParserResultEventArgs>
    {
        public event EventHandler<RegExpParserResultEventArgs> TextParsed;

        public IParserResult<RegExpRuleType> RegExpParserResult { get; set; }

        public RegExpParserResultPublisher(
            EventHandler<RegExpParserResultEventArgs> textParsed = null, 
            IParserResult<RegExpRuleType> regExpParserResult = null)
        {
            RegExpParserResult = regExpParserResult;
            TextParsed = textParsed;
        }

        public void Publish()
        {
            TextParsed?.Invoke(RegExpParserResult, new RegExpParserResultEventArgs(RegExpParserResult));
        }
    }
}
