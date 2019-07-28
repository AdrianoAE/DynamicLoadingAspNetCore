using System.Collections.Generic;

namespace Payments.Interfaces
{
    public interface IPaymentMethod
    {
        int Id { get; set; }
        string Image { get; set; }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        string Create(string invoiceId, decimal amount);

        Dictionary<string, object> Get(string paymentId);
    }
}
