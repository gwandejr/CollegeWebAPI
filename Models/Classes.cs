using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeDBEF.Models
{
    public class Classes
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int TitleID { get; set; }
        public int DeptID { get; set; }

        //Added instructor after the initial migration
        public string Instructor { get; set; }

    }
}