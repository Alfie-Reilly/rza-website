using RZA_AR.Models;
using Microsoft.EntityFrameworkCore;
namespace RZA_AR.Services
{
    public class RoombookingService
    {
        private readonly TlS2302631RzaZooContext _context;
        public RoombookingService(TlS2302631RzaZooContext context)
        {
            _context = context;
        }
        public async Task AddRoombookingAsync(Customer customer, Room room, DateOnly startDate, int duration)
        {
            Roombooking newRoombooking = new Roombooking();
            newRoombooking.Customer = customer;
            newRoombooking.RoomNumberNavigation = room;
            newRoombooking.CheckinDate = startDate;
            newRoombooking.CheckoutDate = startDate.AddDays(duration);
            //var temps = await _context.Roombookings.ToListAsync();

            var temp = await _context.Roombookings.Where(r => r.CustomerId == customer.CustomerId &&
                                                         r.RoomNumber == room.Roomnumber &&
                                                         r.CheckinDate == newRoombooking.CheckoutDate).FirstOrDefaultAsync();
            if (temp == null)
            {
                await _context.Roombookings.AddAsync(newRoombooking);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("could not book room");
            }
            newRoombooking = null;
        }
        public async Task<List<Roombooking>> GetRoombookingsFromCustomer(Customer customer)
        {
            return await _context.Roombookings.Where(rb => rb.CustomerId == customer.CustomerId).ToListAsync();
        }
        public async Task<List<Roombooking>> GetRoombookingsFromCustomer(int id)
        {
            return await _context.Roombookings.Where(rb => rb.CustomerId == id).ToListAsync();
        }
        public async Task DeleteBooking(Roombooking roombooking)
        {
            _context.Roombookings.Remove(roombooking);
            await _context.SaveChangesAsync();
        }
    }
}