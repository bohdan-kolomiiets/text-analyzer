using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextAnalyzer.API.Models
{
    public class DataDTO: BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DataValue { get; set; }
    }
}