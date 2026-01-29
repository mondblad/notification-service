namespace Tutorium.NotificationService.Core.Email.Abstractions
{
    public interface IEmailSender
    {
        Task SendAsync(IEmailMessage message);
    }
}
