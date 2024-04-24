using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCWRegistration.Models.DTOs;


namespace CGCWRegistration.DAL.LanguageRepository
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<LanguageDTO>> GetAllLanguagesAsync();
    }
}
