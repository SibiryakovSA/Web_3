using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_3_6.Models.DataBase.Classes
{
    public class Issue
    {
        public int id { get; set; }
        public string issueText { get; set; }
        public string issueName { get; set; }
        public bool isComplited { get; set; }
        public int userId { get; set; }
    }
}
