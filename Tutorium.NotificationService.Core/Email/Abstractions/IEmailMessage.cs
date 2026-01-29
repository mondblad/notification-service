namespace Tutorium.NotificationService.Core.Email.Abstractions
{
    public interface IEmailMessage
    {
        string To { get; }
        string Subject { get; } 
        IEmailTemplate EmailTemplate { get; }
    }
}
