namespace CollegeDBEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        TitleID = c.Int(nullable: false),
                        DeptID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeptDescr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScoreTypeID = c.Int(nullable: false),
                        DateAssigned = c.DateTime(nullable: false),
                        DateDue = c.DateTime(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                        PointsEarned = c.Int(nullable: false),
                        PointsPossible = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ScoreTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScoreTypeDescr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        SSN = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentsClassesScores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentsID = c.Int(nullable: false),
                        ClassesID = c.Int(nullable: false),
                        ScoresID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassesID, cascadeDelete: true)
                .ForeignKey("dbo.Scores", t => t.ScoresID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentsID, cascadeDelete: true)
                .Index(t => t.StudentsID)
                .Index(t => t.ClassesID)
                .Index(t => t.ScoresID);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TitleDescr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsClassesScores", "StudentsID", "dbo.Students");
            DropForeignKey("dbo.StudentsClassesScores", "ScoresID", "dbo.Scores");
            DropForeignKey("dbo.StudentsClassesScores", "ClassesID", "dbo.Classes");
            DropIndex("dbo.StudentsClassesScores", new[] { "ScoresID" });
            DropIndex("dbo.StudentsClassesScores", new[] { "ClassesID" });
            DropIndex("dbo.StudentsClassesScores", new[] { "StudentsID" });
            DropTable("dbo.Titles");
            DropTable("dbo.StudentsClassesScores");
            DropTable("dbo.Students");
            DropTable("dbo.ScoreTypes");
            DropTable("dbo.Scores");
            DropTable("dbo.Departments");
            DropTable("dbo.Classes");
        }
    }
}
