using System;
using System.Collections.Generic;
using System.Web;
using CGCWRegistration.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Configuration;


namespace CGCWRegistration.DAL
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext(): base(GetConnectionString()) { }

        private static string GetConnectionString()
        {
            // Fetch the base connection string from the web.config
            var connectionString = ConfigurationManager.ConnectionStrings["RegistrationContext"].ConnectionString;

            // Retrieve user ID and password from environment variables
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            // Append the user ID and password to the connection string
            return $"{connectionString}User ID={dbUser};Password={dbPassword};";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AgeRange> AgeRanges { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ResponseOption> ResponseOptions { get; set; }
        public DbSet<UserResponse> UserResponses { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // User to AgeRange (One-to-Many)
            modelBuilder.Entity<User>()
                .HasRequired(u => u.AgeRange)
                .WithMany(ar => ar.Users)
                .HasForeignKey(u => u.AgeRangeID);

            // UserLanguage (Many-to-One with User and Language)
            modelBuilder.Entity<UserLanguage>()
                .HasRequired(ul => ul.User)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(ul => ul.UserID);

            modelBuilder.Entity<UserLanguage>()
                .HasRequired(ul => ul.Language)
                .WithMany(l => l.UserLanguages)
                .HasForeignKey(ul => ul.LanguageID);

            // UserResponse (Many-to-One with User, Question through ResponseOption, and ResponseOption)
            modelBuilder.Entity<UserResponse>()
                .HasRequired(ur => ur.User)
                .WithMany(u => u.UserResponses)
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserResponse>()
                .HasRequired(ur => ur.ResponseOption)
                .WithMany(ro => ro.UserResponses)
                .HasForeignKey(ur => ur.ResponseOptionID);

            // ResponseOption to Question (Many-to-One)
            modelBuilder.Entity<ResponseOption>()
                .HasRequired(ro => ro.Question)
                .WithMany(q => q.ResponseOptions)
                .HasForeignKey(ro => ro.QuestionID)
                .WillCascadeOnDelete(false);
        }
    }
}