using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Interfaces.Rule
{
    interface IMultipleRegExpRules<T>: IRegExpRule<T> where T: struct
    {
        IEnumerable<string> RegularExpressions { get; }
    }
}
