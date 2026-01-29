using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Tutorium.Grpc.Notification;
using Tutorium.NotificationService.Core.Email.Abstractions;
using NotificationServiceBase = Tutorium.Grpc.Notification.NotificationService.NotificationServiceBase;

namespace Tutorium.NotificationService.Grpc
{
    internal class NotificationGrpcService : NotificationServiceBase
    {
        private readonly ISendEmailVerificationCodeUseCase _sendEmailVerificationCodeUseCase;

        public NotificationGrpcService(ISendEmailVerificationCodeUseCase sendEmailVerificationCodeUseCase) 
        {
            _sendEmailVerificationCodeUseCase = sendEmailVerificationCodeUseCase;
        }

        public async override Task<Empty> SendEmailVerificationCode(SendEmailVerificationCodeRequest request, ServerCallContext context)
        {
            await _sendEmailVerificationCodeUseCase.SendConfirmEmail(request.ToEmail, request.Code);

            return new Empty();
        }
    }
}
