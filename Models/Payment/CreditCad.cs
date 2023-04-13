namespace ProvaPub.Models.Payment
{
    public class CreditCad : PaymentCustomer
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
