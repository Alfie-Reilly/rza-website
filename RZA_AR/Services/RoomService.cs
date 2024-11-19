using RZA_AR.Models;
using Microsoft.EntityFrameworkCore;

namespace RZA_AR.Services
{
    public class RoomService
    {
        private readonly TlS2302631RzaZooContext _context;
        public RoomService(TlS2302631RzaZooContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomAsync(int roomNumber)
        {
            return await _context.Rooms.FirstAsync(r => r.Roomnumber == roomNumber);
        }
    }
}