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
        IParserResult<T> ParentParserReult { get; }
        string SourseText { get; }
        IEnumerable<KeyValuePair<int, string>> Entries { get; }
    }
}
