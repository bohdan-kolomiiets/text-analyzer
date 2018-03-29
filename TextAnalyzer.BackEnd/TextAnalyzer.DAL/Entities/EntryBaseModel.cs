using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.DAL.Entities
{
    public class EntryBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
