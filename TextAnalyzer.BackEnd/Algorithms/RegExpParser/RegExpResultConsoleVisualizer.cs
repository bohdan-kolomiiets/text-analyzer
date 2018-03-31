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
    public class RegExpResultConsoleVisualizer : IRegExpResultVisualizer<RegExpParserResultEventArgs>
    {
        public void Visualize(object source, RegExpParserResultEventArgs args)
        {
            Console.WriteLine("------- {0} -------", args.RegExpParserResult.RuleTitle.ToUpper());
            foreach (var entry in args.RegExpParserResult.Entries)
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);
        }
    }
}
