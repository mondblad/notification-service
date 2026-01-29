using MailKit.Net.Smtp;
using MimeKit;
using Tutorium.NotificationService.Core.Email.Abstractions;
using Microsoft.Extensions.Options;

namespace Tutorium.NotificationService.Infrastructure.Email
{
    internal class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpOptions _smtpOptions;
        private readonly IEmailTemplateRenderer _emailTemplateRenderer;

        public SmtpEmailSender(IOptions<SmtpOptions> smtpOptions, IEmailTemplateRenderer emailTemplateRenderer)
        {
            _smtpOptions = smtpOptions.Value;
            _emailTemplateRenderer = emailTemplateRenderer;
        }

        public async Task SendAsync(IEmailMessage emailMessage)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(
                _smtpOptions.FromName,
                _smtpOptions.FromEmail
            ));

            mimeMessage.To.Add(MailboxAddress.Parse(emailMessage.To));
            mimeMessage.Subject = emailMessage.Subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = await _emailTemplateRenderer.RenderAsync(emailMessage.EmailTemplate),
                TextBody = mimeMessage.Subject,
            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port, _smtpOptions.UseSsl);
            await client.AuthenticateAsync(_smtpOptions.Username, _smtpOptions.Password);

            await client.SendAsync(mimeMessage);

            await client.DisconnectAsync(true);
        }
    }
}
