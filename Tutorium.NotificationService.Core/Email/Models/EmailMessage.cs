using Tutorium.NotificationService.Core.Email.Abstractions;

namespace Tutorium.NotificationService.Core.Email.Models
{
    internal class EmailMessage : IEmailMessage
    {
        public EmailMessage(string to, string subject, IEmailTemplate emailTemplate)
        {
            To = to;
            Subject = subject;
            EmailTemplate = emailTemplate;
        }

        public string To { get; init; } = default!;
        public string Subject { get; init; } = default!;
        public IEmailTemplate EmailTemplate { get; init; } = default!;
    }
}
