using Microsoft.AspNetCore.Mvc;

namespace Braintree.Api
{
    public class TestController : Controller
    {

        public IActionResult ActivateModule(string name)
        {
            return Ok("hihi");
        }
    }
}
