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

        public string asd { get; set; }

        public void OnGet()
        {
            string teste = "";

            foreach (var item in _payments.PaymentMethods)
            {
                teste += $" - {item.Value.Name}\n";
            }

            asd = teste;
        }
    }
}
