using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models.Interfaces.Rule
{
    public interface IRegExpRule<T>: IRule<T> where T: struct
    {
    }
}
