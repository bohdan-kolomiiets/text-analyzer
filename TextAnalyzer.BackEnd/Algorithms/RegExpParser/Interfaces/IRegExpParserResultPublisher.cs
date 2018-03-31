using Algorithms.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.RegExpParser.Interfaces
{
    public interface IRegExpParserResultPublisher<RuleT, EventArgT> where RuleT : struct
    {
        event EventHandler<EventArgT> TextParsed;

        IParserResult<RuleT> RegExpParserResult { get; set; }

        void Publish();
    }
}
