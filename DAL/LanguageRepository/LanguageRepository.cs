using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity; // For EF 6 to support async operations
using System.Web;
using CGCWRegistration.Models.DTOs;

namespace CGCWRegistration.DAL.LanguageRepository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly RegistrationContext _context;
        public LanguageRepository(RegistrationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LanguageDTO>> GetAllLanguagesAsync()
        {
            var languages = await _context.Languages
                .Select(l => new LanguageDTO
                {
                    Id = l.LanguageID,
                    Name = l.LanguageName
                }).ToListAsync();
            return languages;
        }
    }
}