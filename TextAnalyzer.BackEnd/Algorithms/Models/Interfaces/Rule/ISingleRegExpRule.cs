using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Interfaces.Rule
{
    public interface ISingleRegExpRule<T>: IRegExpRule<T> where T: struct
    {
        string RegularExpression { get; }
    }
}
