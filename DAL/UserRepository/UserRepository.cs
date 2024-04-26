using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CGCWRegistration.Models.DTOs;

namespace CGCWRegistration.DAL.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly RegistrationContext _context;
        public UserRepository(RegistrationContext context)
        {
            _context = context;
        }
        // GET ALL USERS
        public async Task<IEnumerable<User>> GetAllAgeUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // ADD USER TO DB
        public async Task AddUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException(nameof(userDTO));
            }
            // all or nothing Entity Framework transaction
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = new User
                    {
                        FirstName = userDTO.FirstName,
                        LastName = userDTO.LastName,
                        ChineseName = userDTO.ChineseName,
                        Sex = userDTO.Sex,
                        Occupation = userDTO.Occupation,
                        AgeRangeID = userDTO.AgeRangeID,
                        PhoneNumber = userDTO.PhoneNumber,
                        Email = userDTO.Email,
                        Address = userDTO.Address,
                        IntroducedBy = userDTO.IntroducedBy,
                        ExistingMember = userDTO.ExistingMember,
                        RegistrationDate = DateTime.Now,
                    };

                    _context.Users.Add(user);
                    // Add use to get UserID
                    await _context.SaveChangesAsync();

                    // Add languages
                    foreach (var languageID in userDTO.SelectedLanguageIds)
                    {
                        var userLanguage = new UserLanguage { UserID = user.UserID, LanguageID = languageID };
                        _context.UserLanguages.Add(userLanguage);
                    }

                    // Add responses
                    foreach (var questionResponse in userDTO.Responses)
                    {
                        var userResponse = new UserResponse
                        {
                            UserID = user.UserID,
                            QuestionID = questionResponse.QuestionId,
                            ResponseOptionID = questionResponse.ResponseId
                        };
                        _context.UserResponses.Add(userResponse);
                    }

                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw; // Re-throw the exception to be handled elsewhere
                }
            }
        }
    }
}