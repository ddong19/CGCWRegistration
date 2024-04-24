using CGCWRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGCWRegistration.Models.DTOs;


namespace CGCWRegistration.DAL.AgeRangeRepository
{
    public interface IAgeRangeRepository
    {
        Task<IEnumerable<AgeRangeDTO>> GetAllAgeRangesAsync();
    }
}
