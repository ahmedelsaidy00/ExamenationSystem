namespace ExamenationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exam_Questions",
                c => new
                    {
                        Ex_Id = c.Int(nullable: false),
                        Que_Id = c.Int(nullable: false),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ex_Id, t.Que_Id })
                .ForeignKey("dbo.Exams", t => t.Ex_Id)
                .ForeignKey("dbo.Questions", t => t.Que_Id)
                .Index(t => t.Ex_Id)
                .Index(t => t.Que_Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Ex_Id = c.Int(nullable: false, identity: true),
                        Ex_Name = c.String(nullable: false, maxLength: 50),
                        Time = c.Int(),
                        Sub_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Ex_Id)
                .ForeignKey("dbo.Subjects", t => t.Sub_Id)
                .Index(t => t.Sub_Id);
            
            CreateTable(
                "dbo.StdsAnswers",
                c => new
                    {
                        Que_Id = c.Int(nullable: false),
                        Ex_Id = c.Int(nullable: false),
                        Std_Id = c.Int(nullable: false),
                        Choose_Answer = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Que_Id, t.Ex_Id, t.Std_Id })
                .ForeignKey("dbo.Questions", t => t.Que_Id)
                .ForeignKey("dbo.Students", t => t.Std_Id)
                .ForeignKey("dbo.Exams", t => t.Ex_Id)
                .Index(t => t.Que_Id)
                .Index(t => t.Ex_Id)
                .Index(t => t.Std_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Que_Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Type = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        Answers_Options = c.String(),
                        Correct_Answers = c.String(),
                        Image = c.String(maxLength: 20, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Que_Id)
                .ForeignKey("dbo.Types", t => t.Type)
                .Index(t => t.Type);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Type_Id = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                        MCQ = c.String(nullable: false, maxLength: 50),
                        True_False = c.Boolean(),
                        Image = c.Binary(maxLength: 100, fixedLength: true),
                    })
                .PrimaryKey(t => t.Type_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Std_Id = c.Int(nullable: false),
                        Std_Name = c.String(nullable: false, maxLength: 50),
                        Std_Address = c.String(nullable: false, maxLength: 50),
                        Std_Age = c.Int(nullable: false),
                        Std_Fauclty = c.String(nullable: false, maxLength: 50),
                        Std_University = c.String(nullable: false, maxLength: 50),
                        User_Id = c.Int(nullable: false),
                        Phone = c.String(maxLength: 12, fixedLength: true, unicode: false),
                        Track_id = c.Int(),
                        Degree = c.Double(),
                        CreateDate = c.DateTime(storeType: "date"),
                        CreateID = c.Int(),
                        EditID = c.Int(),
                        EditDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.Std_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Trs_Id = c.Int(nullable: false),
                        Trs_Name = c.String(nullable: false, maxLength: 50),
                        Std_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Trs_Id)
                .ForeignKey("dbo.Students", t => t.Std_Id)
                .Index(t => t.Std_Id);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        Inst_Id = c.Int(nullable: false, identity: true),
                        Inst_Name = c.String(nullable: false, maxLength: 50),
                        Inst_Age = c.Int(nullable: false),
                        Inst_Address = c.String(maxLength: 50),
                        Inst_Phone = c.String(nullable: false, maxLength: 50),
                        User_Id = c.Int(nullable: false),
                        Admin_Id = c.Int(nullable: false),
                        Track_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Inst_Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id)
                .Index(t => t.Track_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Sub_Id = c.Int(nullable: false, identity: true),
                        Sub_Name = c.String(nullable: false, maxLength: 50),
                        Track_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Sub_Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id)
                .Index(t => t.Track_Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        User_Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.User_Id);
            
            CreateTable(
                "dbo.Tracks_Subjects",
                c => new
                    {
                        Sub_Id = c.Int(nullable: false),
                        Trs_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sub_Id, t.Trs_Id })
                .ForeignKey("dbo.Subjects", t => t.Sub_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Trs_Id, cascadeDelete: true)
                .Index(t => t.Sub_Id)
                .Index(t => t.Trs_Id);
            
            CreateTable(
                "dbo.Subjects_Instructors",
                c => new
                    {
                        Inst_Id = c.Int(nullable: false),
                        Sub_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inst_Id, t.Sub_Id })
                .ForeignKey("dbo.Instructor", t => t.Inst_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Sub_Id, cascadeDelete: true)
                .Index(t => t.Inst_Id)
                .Index(t => t.Sub_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StdsAnswers", "Ex_Id", "dbo.Exams");
            DropForeignKey("dbo.Subjects", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Tracks", "Std_Id", "dbo.Students");
            DropForeignKey("dbo.Instructor", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Subjects_Instructors", "Sub_Id", "dbo.Subjects");
            DropForeignKey("dbo.Subjects_Instructors", "Inst_Id", "dbo.Instructor");
            DropForeignKey("dbo.Tracks_Subjects", "Trs_Id", "dbo.Tracks");
            DropForeignKey("dbo.Tracks_Subjects", "Sub_Id", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "Sub_Id", "dbo.Subjects");
            DropForeignKey("dbo.StdsAnswers", "Std_Id", "dbo.Students");
            DropForeignKey("dbo.Questions", "Type", "dbo.Types");
            DropForeignKey("dbo.StdsAnswers", "Que_Id", "dbo.Questions");
            DropForeignKey("dbo.Exam_Questions", "Que_Id", "dbo.Questions");
            DropForeignKey("dbo.Exam_Questions", "Ex_Id", "dbo.Exams");
            DropIndex("dbo.Subjects_Instructors", new[] { "Sub_Id" });
            DropIndex("dbo.Subjects_Instructors", new[] { "Inst_Id" });
            DropIndex("dbo.Tracks_Subjects", new[] { "Trs_Id" });
            DropIndex("dbo.Tracks_Subjects", new[] { "Sub_Id" });
            DropIndex("dbo.Subjects", new[] { "Track_Id" });
            DropIndex("dbo.Instructor", new[] { "Track_Id" });
            DropIndex("dbo.Tracks", new[] { "Std_Id" });
            DropIndex("dbo.Questions", new[] { "Type" });
            DropIndex("dbo.StdsAnswers", new[] { "Std_Id" });
            DropIndex("dbo.StdsAnswers", new[] { "Ex_Id" });
            DropIndex("dbo.StdsAnswers", new[] { "Que_Id" });
            DropIndex("dbo.Exams", new[] { "Sub_Id" });
            DropIndex("dbo.Exam_Questions", new[] { "Que_Id" });
            DropIndex("dbo.Exam_Questions", new[] { "Ex_Id" });
            DropTable("dbo.Subjects_Instructors");
            DropTable("dbo.Tracks_Subjects");
            DropTable("dbo.Users");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Subjects");
            DropTable("dbo.Instructor");
            DropTable("dbo.Tracks");
            DropTable("dbo.Students");
            DropTable("dbo.Types");
            DropTable("dbo.Questions");
            DropTable("dbo.StdsAnswers");
            DropTable("dbo.Exams");
            DropTable("dbo.Exam_Questions");
        }
    }
}
