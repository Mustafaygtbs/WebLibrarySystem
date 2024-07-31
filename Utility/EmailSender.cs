using Microsoft.AspNetCore.Identity.UI.Services;
namespace WebLibrarySystem.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // email gönderme işlemleri buraya eklenecek.
            return Task.CompletedTask;
        }
    }
}
