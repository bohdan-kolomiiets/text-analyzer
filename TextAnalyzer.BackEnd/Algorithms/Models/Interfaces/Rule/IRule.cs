using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Interfaces.Rule
{
    public interface IRule<T> where T: struct
    {
        string Title { get; }
        T RuleType { get; }

    }
}
