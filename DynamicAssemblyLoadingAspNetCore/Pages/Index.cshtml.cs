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

/*

            try
            {

                //-------- Direct Access --------

                test += "\n";
                //test += _payments.Providers["EasyPay"].PaymentMethods["DebitoDireto"].Create("", 0);

                //After [] Overload
                test += "\n";
                test += "TESTEEEEEEEEEEEEEE: " + _payments["EasyPay"]["BoletoBancario"].Create("IdEncomenda", 9.99m);

                //Get Dynamic
                //test += "\n";
                //test += "\n";
                //foreach (var item in _payments["EasyPay"]["Multibanco"].Get("idPagamento"))
                //{
                //    test += $"{item.Key}: {item.Value}\n";
                //}

                test += "\n";
                test += "\n";
                test += "TESTEEEEEEEEEEEEEE: \n";
                foreach (var item in _payments["EasyPay"]["BoletoBancario"].Get("IdEncomenda"))
                {
                    test += $"{item.Key}: {item.Value}\n";
                }
            }
            catch (System.Exception)
            {
            }

            try
            {


                //Get Dynamic
                test += "\n";
                test += "\n";
                test += "ID: " + _payments["Braintree"]["Paypal"].Create("", 0);
                test += "\n";
                foreach (var item in _payments["Braintree"]["Paypal"].Get("idPagamento"))
                {
                    test += $"{item.Key}: {item.Value}\n";
                }
            }
            catch (System.Exception)
            {
            }
 */
