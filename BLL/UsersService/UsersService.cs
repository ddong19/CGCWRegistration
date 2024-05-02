﻿using CGCWRegistration.DAL.AgeRangeRepository;
using CGCWRegistration.DAL.LanguageRepository;
using CGCWRegistration.DAL.QuestionRepository;
using CGCWRegistration.DAL.UserRepository;
using CGCWRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.BLL.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAgeRangeRepository _ageRangeRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IQuestionRepository _questionRepository;

        public UsersService(IUserRepository userRepository, IAgeRangeRepository ageRangeRepository,
                            ILanguageRepository languageRepository, IQuestionRepository questionRepository)
        {
            _userRepository = userRepository;
            _ageRangeRepository = ageRangeRepository;
            _languageRepository = languageRepository;
            _questionRepository = questionRepository;
        }
        public async Task<List<UsersViewModel>> PrepareUsersViewModelAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var viewModel = users.Select(u => new UsersViewModel
            {
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
            return viewModel;
        }
    }
}