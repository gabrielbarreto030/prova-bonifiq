namespace ProvaPub.Models.Payment
{
    public class Paypal : PaymentCustomer
    {
        public override Task<Order> toPay()
        {
        
            //pagar
            return Task.FromResult(new Order()
            {
                Value = this.valuePayment
            });
        }
    }
}
