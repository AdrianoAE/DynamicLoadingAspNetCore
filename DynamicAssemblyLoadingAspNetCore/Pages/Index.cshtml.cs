using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicAssemblyLoadingAspNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPayments _payments;

        public IndexModel(IPayments payments)
        {
            _payments = payments;
        }

        public string loaded { get; set; }

        public void OnGet()
        {
            string test = "";

            foreach (var item in _payments.PaymentMethods)
            {
                test += $"{item.Key} - {item.Value.Name}\n";
            }

            loaded = test;
        }
    }
}
