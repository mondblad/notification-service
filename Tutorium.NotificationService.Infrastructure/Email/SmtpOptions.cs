namespace Tutorium.NotificationService.Infrastructure.Email
{
    internal class SmtpOptions
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public bool UseSsl { get; init; }
        public string FromEmail { get; init; }
        public string FromName { get; init; }
    }
}
