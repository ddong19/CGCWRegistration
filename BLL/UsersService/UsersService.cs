﻿using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.LanguageRepository;
using CGCWRegistration.DAL.QuestionRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.Models.ViewModels;
using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.BuilderProperties;
using System.Web.Helpers;

namespace CGCWRegistration.BLL.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuestionRepository _questionRepository;

        public UsersService(IUserRepository userRepository, IQuestionRepository questionRepository)
        {
            _userRepository = userRepository;
            _questionRepository = questionRepository;
        }

        public async Task<List<UsersViewModel>> ListUsersAsync()
        {
            IEnumerable<User> users = await _userRepository.GetAllUsersAsync();
            List<UsersViewModel> vmUsers = users
                .Select(u => new UsersViewModel
                {
                    Id = u.UserID,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ChineseName = u.ChineseName,
                    Sex = u.Sex,
                    Occupation = u.Occupation,
                    AgeRange = u.AgeRange.Range,
                    PhoneNumber = u.PhoneNumber,
                    Email = u.Email,
                    Address = u.Address,
                    IntroducedBy = u.IntroducedBy,
                    ExistingMember = u.ExistingMember,
                    Languages = u.UserLanguages.Select(l => l.Language.LanguageName).ToList(),
                    Responses = u.UserResponses.Select(r => new QuestionResponseViewModel
                    {
                        QuestionId = r.QuestionID,
                        Question = r.Question.QuestionText,
                        Response = r.ResponseOption.ResponseOptionText
                    }).ToList()
                }).ToList();
            return vmUsers;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user;
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}