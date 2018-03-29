using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextAnalyzer.API.Models
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}