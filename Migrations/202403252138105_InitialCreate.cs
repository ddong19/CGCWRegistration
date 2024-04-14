namespace CGCWRegistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeRanges",
                c => new
                    {
                        AgeRangeID = c.Int(nullable: false, identity: true),
                        Range = c.String(),
                    })
                .PrimaryKey(t => t.AgeRangeID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ChineseName = c.String(),
                        Sex = c.String(),
                        Occupation = c.String(),
                        AgeRangeID = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        IntroducedBy = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        ExistingMember = c.String(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.AgeRanges", t => t.AgeRangeID, cascadeDelete: true)
                .Index(t => t.AgeRangeID);
            
            CreateTable(
                "dbo.UserLanguages",
                c => new
                    {
                        UserLanguageID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        LanguageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserLanguageID)
                .ForeignKey("dbo.Languages", t => t.LanguageID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.LanguageID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.UserResponses",
                c => new
                    {
                        UserResponseID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        ResponseOptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserResponseID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.ResponseOptions", t => t.ResponseOptionID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.QuestionID)
                .Index(t => t.ResponseOptionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.ResponseOptions",
                c => new
                    {
                        ResponseOptionID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        ResponseOptionText = c.String(),
                    })
                .PrimaryKey(t => t.ResponseOptionID)
                .ForeignKey("dbo.Questions", t => t.QuestionID)
                .Index(t => t.QuestionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserResponses", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserResponses", "ResponseOptionID", "dbo.ResponseOptions");
            DropForeignKey("dbo.UserResponses", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.ResponseOptions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.UserLanguages", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserLanguages", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.Users", "AgeRangeID", "dbo.AgeRanges");
            DropIndex("dbo.ResponseOptions", new[] { "QuestionID" });
            DropIndex("dbo.UserResponses", new[] { "ResponseOptionID" });
            DropIndex("dbo.UserResponses", new[] { "QuestionID" });
            DropIndex("dbo.UserResponses", new[] { "UserID" });
            DropIndex("dbo.UserLanguages", new[] { "LanguageID" });
            DropIndex("dbo.UserLanguages", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "AgeRangeID" });
            DropTable("dbo.ResponseOptions");
            DropTable("dbo.Questions");
            DropTable("dbo.UserResponses");
            DropTable("dbo.Languages");
            DropTable("dbo.UserLanguages");
            DropTable("dbo.Users");
            DropTable("dbo.AgeRanges");
        }
    }
}
