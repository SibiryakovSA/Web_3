using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_3_6.Models.DataBase.Classes;

namespace Web_3_6.Models.DataBase
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public int role { get; set; }
    }
}
