
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

namespace ProvaPub.Tests
  
{
  
    public class CustomerServiceTests
    {

        [Fact]
        public async  Task CanPurchase_Returns_False_ForInvalidCustomerId()
        {

            //Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                  .UseInMemoryDatabase(databaseName: "TesteProva")
                  .Options;
            using var context = new TestDbContext(options);
            var service = new CustomerService(context);

            //Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.CanPurchase(-1, 50m));            

        }


        [Fact]
        public async Task CanPurchase_ReturnsFalse_ForMultiplePurchasesInSameMonth()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                 .UseInMemoryDatabase(databaseName: "TesteProva")
                 .Options;
            using var context = new TestDbContext(options);

            var customer = new Customer { Id = 20, Name = "TesteProva" };
            context.Customers.Add(customer);

            var order1 = new Order { CustomerId = 20, OrderDate = DateTime.UtcNow };
            var order2 = new Order { CustomerId = 20, OrderDate = DateTime.UtcNow.AddHours(-1) };
            context.Orders.AddRange(order1, order2);

            await context.SaveChangesAsync();

            var service = new CustomerService(context);

            //Act
            var result = await service.CanPurchase(customer.Id, 50m);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CanPurchase_ReturnsFalse_ForNonExistingCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TesteProva")
                .Options;
            using var context = new TestDbContext(options);

            var service = new CustomerService(context);

            //Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.CanPurchase(1, 50m));
        }


      
    }
}
