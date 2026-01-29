namespace Tutorium.NotificationService.Core.Email.Abstractions
{
    public interface ISendEmailVerificationCodeUseCase
    {
        Task SendConfirmEmail(string toEmail, string code);
    }
}
