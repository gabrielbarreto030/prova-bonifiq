namespace ProvaPub.Models.Payment
{
    public abstract class PaymentCustomer
    {

        public string methodPayment { get; set; }
        public decimal valuePayment { get; set; }
        public int custumerId { get; set; }
        public abstract Task<Order> toPay();
        
    }
}
