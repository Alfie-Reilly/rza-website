using Microsoft.EntityFrameworkCore;
using RZA_AR.Models;

namespace RZA_AR.Services
{
    public class AttractionService
    {
        private readonly TlS2302631RzaZooContext _context;

        public AttractionService(TlS2302631RzaZooContext context)
        {
            _context = context;
        }

        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}
