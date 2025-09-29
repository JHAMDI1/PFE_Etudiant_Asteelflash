using PFE_Etudiant_Asteelflash .Domain.Not_Mapped_Entities;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.External
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage emailMessage);
        Task SendWelcomeEmailAsync(string email, string username);
        Task SendPasswordResetEmailAsync(string email, string resetToken, string userId);
        Task SendEmailConfirmationAsync(string email, string confirmationToken, string userId);
    }
}
