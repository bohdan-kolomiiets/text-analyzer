using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextAnalyzer.API.Models
{
    public class RegularExpressionDTO: BaseDTO
    {
        public int RuleId { get; set; }

        public string RegExp { get; set; }
    }
}