using Tutorium.NotificationService.Core.Email.Abstractions;
using Tutorium.NotificationService.Core.Email.Models;

namespace Tutorium.NotificationService.Core.Email.UseCase
{
    internal class SendEmailVerificationCodeUseCase : ISendEmailVerificationCodeUseCase
    {
        private readonly IEmailSender _emailSender;

        public SendEmailVerificationCodeUseCase(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendConfirmEmail(string toEmail, string code)
        {
            var template = new ConfirmEmailTemplate(code);

            var message = new EmailMessage(toEmail, "это тестовое письмо подтверждения", template);

            await _emailSender.SendAsync(message);
        }
    }
}
