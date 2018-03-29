using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextAnalyzer.API.Models
{
    public class AppliedRuleResultDTO: BaseDTO
    {
        public int AppliedRuleId { get; set; }

        public int? IndexInText { get; set; }
        public string Value { get; set; }
    }
}