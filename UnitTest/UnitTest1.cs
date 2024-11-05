using RZA_AR.Components;
using RZA_AR.Services;
using RZA_AR.Models;
using Microsoft.EntityFrameworkCore;

namespace UnitTest
{
    public class Tests
    {
        private TlS2302631RzaZooContext _context;
        private CustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TlS2302631RzaZooContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new TlS2302631RzaZooContext(options);
            _customerService = new CustomerService(_context);
        }

        [Test]
        public async Task Test1()
        {
            Customer tempCustomer = new Customer()
            {
                Username = "admin",
                Password = "admin"
            };
            await _customerService.AddCustomerAsync(tempCustomer);
            var result = await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == "admin");
            Assert.IsNotNull(result);
        }
        [TearDown]
        public void TearDown() 
        {
            _context.Dispose();
        }
    }
}