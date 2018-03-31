using Algorithms.Models.Interfaces.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Interfaces
{
    public interface IParserResult<T> where T: struct
    {
        string RuleTitle { get; }
        IParserResult<T> ParentParserReult { get; }
        string SourceText { get; }
        IEnumerable<KeyValuePair<int, string>> Entries { get; }
    }
}
