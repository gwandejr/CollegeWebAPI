namespace CollegeDBEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using CollegeDBEF.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CollegeDBEF.DataAccessLayer.CollegeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CollegeDBEF.DataAccessLayer.CollegeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //The lookup table for the class titles
            var Titles = new List<Titles>
            {
                new Titles { TitleDescr = "Algebra" },
                new Titles { TitleDescr = "Biology" },
                new Titles { TitleDescr = "Marketing" }
            };

            Titles.ForEach(Title => context.Titles.AddOrUpdate(T => new { T.TitleDescr },Title));
            context.SaveChanges();

            //The lookup table for the class departments
            var Departments = new List<Departments>
            {
                new Departments { DeptDescr = "Math" },
                new Departments { DeptDescr = "Science" },
                new Departments { DeptDescr = "Business" }
            };

            Departments.ForEach(Department => context.Departments.AddOrUpdate(D => new { D.DeptDescr },Department));
            context.SaveChanges();

            //The lookup table for the assignment types for scores
            var ScoreTypes = new List<ScoreTypes>
            {
                new ScoreTypes { ScoreTypeDescr = "Homework" },
                new ScoreTypes { ScoreTypeDescr = "Quiz" },
                new ScoreTypes { ScoreTypeDescr = "Exam" }
            };

            ScoreTypes.ForEach(ScoreType => context.ScoreTypes.AddOrUpdate(ST => new { ST.ScoreTypeDescr },
                ScoreType));
            context.SaveChanges();

            //The Classes table
            var Classes = new List<Classes>
            {
                new Classes { TitleID = 1, Number = 101, DeptID = 1, Instructor = "" },
                new Classes { TitleID = 2, Number = 102, DeptID = 2, Instructor = "" },
                new Classes { TitleID = 3, Number = 201, DeptID = 3, Instructor = ""},
                new Classes { TitleID = 3, Number = 400, DeptID = 3, Instructor = "" }
            };

            Classes.ForEach(Class => context.Classes.AddOrUpdate(C => new { C.TitleID, C.Number, C.DeptID}, Class));
            context.SaveChanges();

            /* 4th classes record added to the Classes table above after the initial migration and adding 
             instructor to the Classes table migration */
            //new Classes { TitleID = 3, Number = 400, DeptID = 3, Instructor = "" }

            //The Students table
            var Students = new List<Students>
            {
                new Students {FName = "John", LName = "Smith", SSN = 111223333,
                    Address = "123 Main St.", City = "Anytown", State = "CA", Zip = 93210, Phone = 9032198752},
                new Students { FName = "Jane", LName = "Doe", SSN = 222334444,
                    Address = "03687 Bear Rd.", City = "Rural", State = "OK", Zip = 62184, Phone = 5347403021 },
                new Students { FName = "Jack", LName = "Johnson", SSN = 333445555,
                    Address = "5530 West Av.", City = "Big City", State = "NY", Zip = 01598, Phone = 1209334218 },
                new Students{FName="Todd", LName="Adams", SSN=667889000,
                    Address ="63911 Bridgeport Lane", City ="Ranchland", State="TX", Zip=77524, Phone=6985620289}
            };

            Students.ForEach(Student => context.Students.AddOrUpdate(S => new { S.FName, S.LName, S.SSN,
                S.Address, S.City, S.State, S.Zip, S.Phone},Student));
            context.SaveChanges();

            /* 4th student record added to the Students table above after the initial migration 
            and adding instructor to the Classes table migration */
            //new Students{FName="Todd", LName="Adams", SSN=667889000,
            //    Address ="63911 Bridgeport Lane", City ="Ranchland", State="TX", Zip=77524, Phone=6985620289}

            //The Scores table
            var Scores = new List<Scores>
            {
                new Scores { ScoreTypeID = 1, DateAssigned = DateTime.Parse("2019-01-01"),
                    DateDue = DateTime.Parse("2019-01-07"), DateSubmitted = DateTime.Parse("2019-01-07"),
                    PointsEarned = 9, PointsPossible = 10 },
                new Scores { ScoreTypeID = 2, DateAssigned = DateTime.Parse("2019-01-10"),
                    DateDue = DateTime.Parse("2019-01-10"), DateSubmitted = DateTime.Parse("2019-01-10"),
                    PointsEarned = 6, PointsPossible = 10 },
                new Scores { ScoreTypeID = 3, DateAssigned = DateTime.Parse("2019-01-25"),
                    DateDue = DateTime.Parse("2019-01-25"), DateSubmitted = DateTime.Parse("2019-01-25"),
                    PointsEarned = 28, PointsPossible = 50 },
                new Scores{ScoreTypeID=1,DateAssigned=DateTime.Parse("2019-01-07"),
                    DateDue =DateTime.Parse("2019-01-14"),DateSubmitted=DateTime.Parse("2019-01-14"),
                    PointsEarned =10,PointsPossible=10 }
            };

            Scores.ForEach(Score => context.Scores.AddOrUpdate(S => new { S.ScoreTypeID, S.DateAssigned,
                S.DateDue, S.DateSubmitted, S.PointsEarned, S.PointsPossible},Score));
            context.SaveChanges();

            /* 4th scores record added to the Scores table above after initial migration and adding 
             instructor to the Classes table migration */
            //new Scores{ScoreTypeID=1,DateAssigned=DateTime.Parse("2019-01-07"),
            //        DateDue =DateTime.Parse("2019-01-14"),DateSubmitted=DateTime.Parse("2019-01-14"),
            //        PointsEarned =10,PointsPossible=10 }

            //The intermediary table between Students, Classes, and Scores tables
            var StudentsClassesScores = new List<StudentsClassesScores>
            {
                new StudentsClassesScores {StudentsID = 1, ClassesID = 1, ScoresID = 1 },
                new StudentsClassesScores { StudentsID = 2, ClassesID = 2, ScoresID = 2 },
                new StudentsClassesScores { StudentsID = 3, ClassesID = 3, ScoresID = 3 },
                new StudentsClassesScores { StudentsID = 4, ClassesID = 2, ScoresID = 4 }
            };
            StudentsClassesScores.ForEach(SCS => context.StudentsClassesScores.AddOrUpdate(scs =>
                new { scs.StudentsID, scs.ClassesID, scs.ScoresID }, SCS));
            context.SaveChanges();
            
            /* 4th record added to the intermediary table above after the initial migration
             and adding instructor to the Classes table migration */
            //new StudentsClassesScores { StudentsID = 4, ClassesID = 2, ScoresID = 4 }

            base.Seed(context);
        }
    }
}
