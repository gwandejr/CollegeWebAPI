using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeDBEF.Models
{
    public class StudentsClassesScores
    {
        public int ID { get; set; }

        //Foreign key for Students
        public int StudentsID { get; set; }
        public Students Students { get; set; }

        //Foreign key for Classes
        public int ClassesID { get; set; }
        public Classes Classes { get; set; }

        //Foreign key for Scores
        public int ScoresID { get; set; }
        public Scores Scores { get; set; }
    }
}