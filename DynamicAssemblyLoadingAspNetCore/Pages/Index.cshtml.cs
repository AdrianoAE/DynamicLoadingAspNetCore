using Microsoft.AspNetCore.Mvc.RazorPages;
using Payments.Entities;
using Payments.Interfaces;
using System.Collections.Generic;

namespace DynamicAssemblyLoadingAspNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPayments _payments;

        public IndexModel(IPayments payments)
        {
            _payments = payments;
        }

        public string ActiveModules { get; set; }

        //BACKOFFICE
        public List<Provider> providers { get; set; }
        ///////////

        public void OnGet()
        {
            providers = _payments.GetProviders();

            foreach (var provider in _payments.Providers)
            {
                ActiveModules += $"{provider.Key}:\n";
                foreach (var paymentMethod in provider.Value.PaymentMethods)
                {
                    ActiveModules += $"    • {paymentMethod.Key}\n";
                }
            }

            //_payments["Braintree"]["Paypal"].Create("OrderId", 9.99m);
        }
    }
}
