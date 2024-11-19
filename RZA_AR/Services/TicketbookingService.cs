using Microsoft.EntityFrameworkCore;
using RZA_AR.Models;

namespace RZA_AR.Services
{
    public class TicketbookingService
    {
        private readonly TlS2302631RzaZooContext _context;
        public TicketbookingService(TlS2302631RzaZooContext context)
        {
            _context = context;
        }
        public async Task<List<Ticketbooking>> GetTicketbookingsAsync()
        {
            return await _context.Ticketbookings.ToListAsync();
        }
        public async Task AddTicketbookingAsync(Ticketbooking newTicketbooking)
        {
            await _context.Ticketbookings.AddAsync(newTicketbooking);
            await _context.SaveChangesAsync();
        }
    }
}