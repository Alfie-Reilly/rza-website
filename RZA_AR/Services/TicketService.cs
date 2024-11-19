using Microsoft.EntityFrameworkCore;
using RZA_AR.Models;

namespace RZA_AR.Services
{
    public class TicketService
    {
        private readonly TlS2302631RzaZooContext _context;
        public TicketService(TlS2302631RzaZooContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}
