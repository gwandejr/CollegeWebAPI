using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CollegeDBEF.Models;

namespace CollegeDBEF.DataAccessLayer
{
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("CollegeContext")
        {
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<ScoreTypes> ScoreTypes { get; set; }
        public DbSet<StudentsClassesScores> StudentsClassesScores { get; set; }
    }
}