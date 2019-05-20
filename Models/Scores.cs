using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeDBEF.Models
{
    public class Scores
    {
        public int ID { get; set; }
        public int ScoreTypeID { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int PointsEarned { get; set; }
        public int PointsPossible { get; set; }

    }
}