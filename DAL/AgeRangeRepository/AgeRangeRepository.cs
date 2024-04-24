using CGCWRegistration.Models;
using CGCWRegistration.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CGCWRegistration.DAL.AgeRangeRepository
{
    public class AgeRangeRepository : IAgeRangeRepository
    {
        private readonly RegistrationContext _context;
        public AgeRangeRepository(RegistrationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AgeRangeDTO>> GetAllAgeRangesAsync()
        {
            // Fetch the AgeRanges and project them to AgeRangeDTO
            var ageRanges = await _context.AgeRanges
                .Select(ar => new AgeRangeDTO
                {
                    Id = ar.AgeRangeID,
                    Range = ar.Range
                }).ToListAsync();

            return ageRanges;
        }
    }
}