using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_temporary_reception.Models
{
    public class Reception
    {
        public string Guide_Number { get; set; }
        public int Operator_Id { get; set; }
        public int Status_Id { get; set; }
        public int Condition_Id { get; set; }
        public string Photography { get; set; }
    }
}