using CGCWRegistration.Models;
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
        public async Task<IEnumerable<AgeRange>> GetAllAgeRangesAsync()
        {
            return await _context.AgeRanges.ToListAsync();
        }
    }
}