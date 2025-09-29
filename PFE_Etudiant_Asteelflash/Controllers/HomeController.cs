using System.Diagnostics;
using PFE_Etudiant_Asteelflash.Models;
using Microsoft.AspNetCore.Mvc;

// ------------------------------------------------------------
// Contrôleur HomeController
// Gère les pages génériques de l'application (accueil, privacy,
// erreur). Sert principalement de point d'entrée après
// authentification.
// ------------------------------------------------------------

namespace PFE_Etudiant_Asteelflash.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Service de log injecté via DI

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Retourne simplement la vue d'accueil (~/Views/Home/Index.cshtml)
            return View();
        }

        public IActionResult Privacy()
        {
            // Affiche la page Privacy décrivant la politique de confidentialité.
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Retourne la vue Error avec l'ID de trace afin de faciliter le débogage.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
