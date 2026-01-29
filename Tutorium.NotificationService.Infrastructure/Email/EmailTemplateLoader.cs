using Tutorium.NotificationService.Core.Email.Abstractions;

namespace Tutorium.NotificationService.Infrastructure.Email
{
    internal class EmailTemplateLoader : IEmailTemplateRenderer
    {
        /// <summary>
        /// Рендерит HTML-шаблон письма, подставляя значения из модели шаблона.
        /// </summary>
        public async Task<string?> RenderAsync(IEmailTemplate emailTemplate)
        {
            var html = await LoadTemplateAsync(emailTemplate.TemplateName);

            foreach (var prop in emailTemplate.GetType().GetProperties())
            {
                var value = prop.GetValue(emailTemplate)?.ToString() ?? "";
                html = html.Replace($"{{{{{prop.Name}}}}}", value);
            }

            return html;
        }

        /// <summary>
        /// Загружает HTML-шаблон письма из файловой системы.
        /// </summary>
        private static async Task<string?> LoadTemplateAsync(string templateName)
        {
            var path = Path.Combine(
                AppContext.BaseDirectory,
                "Email",
                "EmailTemplates",
                templateName
            );

            return await File.ReadAllTextAsync(path);
        }
    }
}
