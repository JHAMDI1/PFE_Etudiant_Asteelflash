using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// ------------------------------------------------------------
// Contrôleur NotificationsController
// Offre deux surfaces :
//   1) API JSON pour récupérer / marquer comme lues les notifications.
//   2) Vues Razor pour afficher la liste complète côté MVC.
// S'appuie sur INotificationService et ApplicationDbContext.
// ------------------------------------------------------------

namespace PFE_Etudiant_Asteelflash.Controllers
{
    
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context; // Contexte EF Core pour accéder aux notifications
        private readonly INotificationService _notificationService; // Encapsule la logique de création/màj des notifications

        public NotificationsController(
            ApplicationDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        // GET: Notifications (API JSON)
        // Retourne la liste des notifications de l'utilisateur au format JSON (vue SPA ou fetch JS)
        [HttpGet("api/notifications")]
        public async Task<IActionResult> GetNotifications(CancellationToken ct = default)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            Console.WriteLine($"Récupération des notifications pour l'utilisateur: {userId}");

            try
            {
                var notifications = await _context.Notification
                    .Where(n => n.UserId == userId && !n.IsRead)
                    .OrderByDescending(n => n.CreatedAt)
                    .ToListAsync(ct);

                Console.WriteLine($"Nombre de notifications trouvées: {notifications.Count}");
                
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des notifications: {ex.Message}");
                return StatusCode(500, "Erreur lors de la récupération des notifications");
            }
        }

        // POST: api/notifications/{id}/read (API)
        // Marque la notification comme lue via appel AJAX
        [HttpPost("api/notifications/{id}/read")]
        public async Task<IActionResult> MarkAsReadApi(int id, CancellationToken ct = default)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var notification = await _context.Notification
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId, ct);

            if (notification == null)
                return NotFound();

            await _notificationService.MarkAsReadAsync(id, ct);
            return NoContent();
        }

        // MVC: Liste complète des notifications
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken ct = default)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Auth");

            var notifications = await _context.Notification
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync(ct);

            return View(notifications);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsRead(int id, CancellationToken ct = default)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Auth");

            var notification = await _context.Notification
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId, ct);

            if (notification == null)
                return NotFound();

            notification.IsRead = true;
            await _context.SaveChangesAsync(ct);

            return RedirectToAction(nameof(Index));
        }
    }
}
