using Tutorium.NotificationService.Core.Email.Abstractions;

namespace Tutorium.NotificationService.Core.Email.Models
{
    internal class ConfirmEmailTemplate : IEmailTemplate
    {
        public ConfirmEmailTemplate(string code)
        {
            Code = code;
        }

        public string TemplateName => "ConfirmEmailTemplate.html";

        public string Code { get; set; } = null!;
    }
}
