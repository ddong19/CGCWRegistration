namespace CGCWRegistration.Migrations
{
    using CGCWRegistration.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CGCWRegistration.DAL.RegistrationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CGCWRegistration.DAL.RegistrationContext";
        }

        protected override void Seed(CGCWRegistration.DAL.RegistrationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            try
            {
                // Seed AgeRanges
                var ageRanges = new List<AgeRange>
                {
                    new AgeRange{Range="≤20"},
                    new AgeRange{Range="21-30"},
                    new AgeRange{Range="31-40"},
                    new AgeRange{Range="41-55"},
                    new AgeRange{Range="56+"},
                };
                foreach (var ageRange in ageRanges)
                {
                    if (!context.AgeRanges.Any(ar => ar.Range == ageRange.Range))
                    {
                        context.AgeRanges.Add(ageRange);
                    }
                }

                // Seed Languages
                var languages = new List<Language>
                {
                    new Language{LanguageName="English"},
                    new Language{LanguageName="Mandarin"},
                    new Language{LanguageName="Cantonese"},
                    new Language{LanguageName="Other"}
                };
                foreach (var language in languages)
                {
                    if (!context.Languages.Any(l => l.LanguageName == language.LanguageName))
                    {
                        context.Languages.Add(language);
                    }
                }

                // Seed Question 1 & Corresponsing Responses
                var questionText = "You came to this church because you";
                var question = context.Questions.SingleOrDefault(q => q.QuestionText == questionText);
                if (question == null)
                {
                    question = new Question { QuestionText = questionText };
                    context.Questions.Add(question);
                    // SaveChanges to get new QuestionID
                    context.SaveChanges();
                }
                var responseOptions = new List<string> { "are visiting", "live in this area" };
                foreach (var optionText in responseOptions)
                {
                    if (!context.ResponseOptions.Any(ro => ro.ResponseOptionText == optionText && ro.QuestionID == question.QuestionID))
                    {
                        var responseOption = new ResponseOption { QuestionID = question.QuestionID, ResponseOptionText = optionText };
                        context.ResponseOptions.Add(responseOption);
                    }
                }
                context.SaveChanges();

                // Seed Question 2 & Corresponsing Responses
                questionText = "Your relationship with God";
                question = context.Questions.SingleOrDefault(q => q.QuestionText == questionText);
                if (question == null)
                {
                    question = new Question { QuestionText = questionText };
                    context.Questions.Add(question);
                    // SaveChanges to get new QuestionID
                    context.SaveChanges();
                }
                responseOptions = new List<string> { "Believed in Him and Baptized", "Believed in Him and not yet Baptized", "Would like to learn more" };
                foreach (var optionText in responseOptions)
                {
                    if (!context.ResponseOptions.Any(ro => ro.ResponseOptionText == optionText && ro.QuestionID == question.QuestionID))
                    {
                        var responseOption = new ResponseOption { QuestionID = question.QuestionID, ResponseOptionText = optionText };
                        context.ResponseOptions.Add(responseOption);
                    }
                }
                context.SaveChanges();

                // Seed Question 3 & Corresponding Responses
                questionText = "Do you like to be visited?";
                question = context.Questions.SingleOrDefault(q => q.QuestionText == questionText);
                if (question == null)
                {
                    question = new Question { QuestionText = questionText };
                    context.Questions.Add(question);
                    // SaveChanges to get new QuestionID
                    context.SaveChanges();
                }
                responseOptions = new List<string> { "Yes", "No", "Maybe" };
                foreach (var optionText in responseOptions)
                {
                    if (!context.ResponseOptions.Any(ro => ro.ResponseOptionText == optionText && ro.QuestionID == question.QuestionID))
                    {
                        var responseOption = new ResponseOption { QuestionID = question.QuestionID, ResponseOptionText = optionText };
                        context.ResponseOptions.Add(responseOption);
                    }
                }
                context.SaveChanges();

                // Seed Question 4 & Corresponding Responses
                questionText = "Do you want to attend our cell group meetings?";
                question = context.Questions.SingleOrDefault(q => q.QuestionText == questionText);
                if (question == null)
                {
                    question = new Question { QuestionText = questionText };
                    context.Questions.Add(question);
                    // SaveChanges to get new QuestionID
                    context.SaveChanges();
                }
                foreach (var optionText in responseOptions)
                {
                    if (!context.ResponseOptions.Any(ro => ro.ResponseOptionText == optionText && ro.QuestionID == question.QuestionID))
                    {
                        var responseOption = new ResponseOption { QuestionID = question.QuestionID, ResponseOptionText = optionText };
                        context.ResponseOptions.Add(responseOption);
                    }
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error seeding the database: {ex.Message}");
                throw; // Re-throw the exception for further investigation
            }
        }
    }
}
