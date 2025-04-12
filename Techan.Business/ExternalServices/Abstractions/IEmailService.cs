namespace Techan.Business.ExternalServices.Abstractions;
internal interface IEmailService
{
    Task SendEmailAsync(EmailSendDto dto);
}
