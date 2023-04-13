using System.Threading.Tasks;

namespace ProvaPub.Models.Payment
{
    public class Pix : PaymentCustomer
    {
        public  override  Task<Order>   toPay() 
            
        {


            //pagar
            return Task.FromResult(new Order()
            {
                Value = this.valuePayment
            });
        }
    }
}
