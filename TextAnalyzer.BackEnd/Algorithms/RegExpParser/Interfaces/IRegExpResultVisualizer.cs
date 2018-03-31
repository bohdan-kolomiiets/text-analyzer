using Algorithms.Models.ConstantsAndEnums;
using Algorithms.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.RegExpParser.Interfaces
{
    public interface IRegExpResultVisualizer<in T> where T: EventArgs
    {
        void Visualize(object source, T args);
    }
}
