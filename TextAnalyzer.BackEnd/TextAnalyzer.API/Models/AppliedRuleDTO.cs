using Algorithms.Models.ConstantsAndEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextAnalyzer.API.Models
{
    public class AppliedRuleDTO: BaseDTO
    {
        public int RuleId { get; set; }
        public int AppliedRuleBlockId { get; set; }
        
        public int Index { get; set; }
        public RulesConnectionType InnerConnectionType { get; set; }

    }
}