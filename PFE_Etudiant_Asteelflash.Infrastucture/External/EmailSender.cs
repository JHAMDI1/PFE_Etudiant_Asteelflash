using MailKit.Net.Smtp;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using PFE_Etudiant_Asteelflash.Domain.Not_Mapped_Entities;
using Microsoft.Extensions.Options;
using System.Web;
using MimeKit;
using MailKit.Security;

namespace PFE_Etudiant_Asteelflash.Infrastucture.External
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            try
            {
                var email = new MimeMessage();

                //From
                email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));

                //To
                email.To.Add(MailboxAddress.Parse(emailMessage.To));

                //Subject
                email.Subject = emailMessage.Subject;

                //Body
                var builder = new BodyBuilder();
                if (emailMessage.IsHtml)
                {
                    builder.HtmlBody = emailMessage.Body;
                }
                else
                {
                    builder.TextBody = emailMessage.Body;
                }

                //Attachments
                if (emailMessage.Attachments != null && emailMessage.Attachments.Any())
                {
                    foreach (var attachment in emailMessage.Attachments)
                    {
                        if (File.Exists(attachment))
                        {
                            builder.Attachments.Add(attachment);
                        }
                    }
                }

                email.Body = builder.ToMessageBody();

                //send email
                using (var client = new SmtpClient())
                {
                    // Utiliser SecureSocketOptions.StartTls pour le port 587
                    await client.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                    await client.SendAsync(email);
                    await client.DisconnectAsync(true);
                }

            }
            catch (Exception ex)
            {
                // Logging de l'erreur
                Console.WriteLine($"Erreur d'envoi d'email: {ex.Message}");
                throw; // Propager l'exception pour pouvoir la g�rer au niveau sup�rieur
            }
        }

        public async Task SendEmailConfirmationAsync(string email, string confirmationToken, string userId)
        {
            var encodedToken = HttpUtility.UrlEncode(confirmationToken);
            // URL modifi�e pour pointer vers notre page HTML de confirmation
            var confirmationLink = $"https://localhost:7276/Auth/ConfirmEmail?token={encodedToken}&userId={userId}";
            var message = new EmailMessage
            {
                To = email,
                Subject = "Confirmation de votre adresse email Asteel Flash FNC",
                Body = $@"
                    <html>
                    <body style=""font-family: Arial, sans-serif; line-height: 1.6;"">
                        <div style=""max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e4e4e4; border-radius: 5px;"">

                            <p>Merci <h1 style=""color: #333; text-align: center;"">
                                Confirmation de votre adresse email
                            </h1>de vous �tre inscrit sur Asteel Flash FNC!</p>
                            <p>Cliquez sur le bouton ci-dessous pour confirmer votre adresse email:</p>
                            <div style=""text-align: center; margin: 30px 0;"">
                                <a href='{confirmationLink}' style=""display: inline-block; background-color: #4CAF50; color: white; padding: 12px 20px; text-decoration: none; border-radius: 4px;"">
                                    Confirmer mon adresse email
                                </a>
                            </div>
                            <p>Ce lien expirera dans 24 heures.</p>
                            <div style=""margin-top: 30px; padding-top: 20px; border-top: 1px solid #e4e4e4;"">
                                <p>Cordialement,<br>L'�quipe Asteel Flash FNC</p>
                            </div>
                        </div>
                    </body>
                    </html>",
                IsHtml = true
            };

            // Envoyer l'email
            await SendEmailAsync(message);
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetToken, string userId)
        {
            var encodedToken = HttpUtility.UrlEncode(resetToken);
            var resetLink = $"https://localhost:7276/Auth/ResetPassword?token={encodedToken}&userId={userId}";
            var message = new EmailMessage
            {
                To = email,
                Subject = "R�initialisation de votre mot de passe",
                Body = $@"
                    <html>
                    <body style=""font-family: Arial, sans-serif; line-height: 1.6;"">
                        <div style=""max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e4e4e4; border-radius: 5px;"">
                            <h1 style=""color: #333; text-align: center;"">
                                R�initialisation de votre mot de passe
                            </h1>
                            <p>Vous avez demand� la r�initialisation de votre mot de passe.</p>
                            <p>Cliquez sur le bouton ci-dessous pour d�finir un nouveau mot de passe:</p>
                            <div style=""text-align: center; margin: 30px 0;"">
                                <a href='{resetLink}' style=""display: inline-block; background-color: #4CAF50; color: white; padding: 12px 20px; text-decoration: none; border-radius: 4px;"">
                                    R�initialiser mon mot de passe
                                </a>
                            </div>
                            <p>Ce lien expirera dans 24 heures.</p>
                            <p>Si vous n'avez pas demand� cette r�initialisation, vous pouvez ignorer cet email.</p>
                            <div style=""margin-top: 30px; padding-top: 20px; border-top: 1px solid #e4e4e4;"">
                                <p>Cordialement,<br>L'�quipe Asteel Flash FNC</p>
                            </div>
                        </div>
                    </body>
                    </html>",
                IsHtml = true
            };

            // Envoyer l'email
            await SendEmailAsync(message);
        }

        public async Task SendWelcomeEmailAsync(string email, string username)
        {
            var message = new EmailMessage
            {
                To = email,
                Subject = "Bienvenue sur Asteel Flash FNC!",
                Body = $@"
                    <html>
                    <body style=""font-family: Arial, sans-serif; line-height: 1.6;"">
                        <div style=""max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e4e4e4; border-radius: 5px;"">
                            <h1 style=""color: #333; text-align: center;"">
                                Bienvenue sur Asteel Flash FNC, {username}!
                            </h1>
                            <p>Nous sommes ravis de vous compter parmi nos utilisateurs.</p>
                            <p>Votre compte a �t� confirm� avec succ�s et est maintenant actif.</p>
                            <p>Voici ce que vous pouvez faire maintenant:</p>
                            <ul>
                                <li>Explorer notre catalogue de produits</li>
                                <li>Cr�er votre liste de souhaits</li>
                                <li>Passer votre premi�re commande</li>
                            </ul>
                            <div style=""text-align: center; margin: 30px 0;"">
                                <a href='https://localhost:7276/' style=""display: inline-block; background-color: #4CAF50; color: white; padding: 12px 20px; text-decoration: none; border-radius: 4px;"">
                                    Commencer mon exp�rience
                                </a>
                            </div>
                            <div style=""margin-top: 30px; padding-top: 20px; border-top: 1px solid #e4e4e4;"">
                                <p>Cordialement,<br>L'�quipe Asteel Flash FNC</p>
                            </div>
                        </div>
                    </body>
                    </html>",
                IsHtml = true
            };

            // Envoyer l'email
            await SendEmailAsync(message);
        }

    }
}
