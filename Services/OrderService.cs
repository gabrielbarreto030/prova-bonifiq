using ProvaPub.Models;
using ProvaPub.Models.Payment;

namespace ProvaPub.Services
{
	public class OrderService
	{
		public async Task<Order> PayOrder(PaymentCustomer paymentCustomer)
		{
			

			return await paymentCustomer.toPay();

            //return await Task.FromResult( new Order()
            //{
            //	Value = paymentValue
            //});
        }
	}
}
