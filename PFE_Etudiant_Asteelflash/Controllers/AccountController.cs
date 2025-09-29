using Microsoft.AspNetCore.Mvc;

namespace PFE_Etudiant_Asteelflash.Controllers
{
    // Provide basic account-related pages like AccessDenied so we avoid 404 when authorization fails
    [Route("Account")]
    public class AccountController : Controller
    {
        // GET: /Account/AccessDenied
        [HttpGet("AccessDenied")]
        public IActionResult AccessDenied(string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
    }
}
