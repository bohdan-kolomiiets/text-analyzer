using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.DAL.Entities
{
    public class AppliedRuleBlock: EntryBaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int DataId { get; set; }
        public virtual Data Data { get; set; }

        public virtual ICollection<AppliedRule> AppliedRules { get; set; } = new Collection<AppliedRule>();

    }
}
