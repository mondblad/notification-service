namespace Tutorium.NotificationService.Core.Email.Abstractions
{
    public interface IEmailTemplateRenderer
    {
        Task<string?> RenderAsync(IEmailTemplate template);
    }
}
