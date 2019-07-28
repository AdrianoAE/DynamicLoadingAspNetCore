using Microsoft.AspNetCore.Mvc;
using Payments.Interfaces;

namespace Payments.API
{
    public class ModuleController : Controller
    {
        private readonly IPayments _payments;

        public ModuleController(IPayments payments)
        {
            _payments = payments;
        }

        public IActionResult ActivateModule(string name)
        {
            _payments.ActivateModule(name);
            
            return Redirect(Request.Host.ToString());
        }
    }
}
