using Tutorium.NotificationService.Core.Email.Abstractions;
using Tutorium.NotificationService.Core.Email.UseCase;
using Tutorium.NotificationService.Grpc;
using Tutorium.NotificationService.Infrastructure.Email;

var builder = WebApplication.CreateBuilder(args);

ConfigureAppSettings(builder);
ConfigureServices(builder);

var app = builder.Build();

ConfigureApp(app);

app.Run();

#region Setup Helpers

void ConfigureAppSettings(WebApplicationBuilder builder)
{
    builder.Configuration
       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

    if (builder.Environment.IsDevelopment())
        builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

    builder.Configuration.AddEnvironmentVariables();
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddGrpc();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IEmailSender, SmtpEmailSender>();
    builder.Services.AddScoped<IEmailTemplateRenderer, EmailTemplateLoader>();

    builder.Services.AddScoped<ISendEmailVerificationCodeUseCase, SendEmailVerificationCodeUseCase>();

    builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));
}

void ConfigureApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapGrpcService<NotificationGrpcService>();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}
    
#endregion Setup Helpers