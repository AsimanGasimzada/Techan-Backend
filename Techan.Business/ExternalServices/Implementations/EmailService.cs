using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Techan.Business.ExternalServices.Abstractions;

namespace Techan.Business.ExternalServices.Implementations;

internal class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly MailKitOptionDto _configurationDto;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
        _configurationDto = _configuration.GetSection("MailkitOptions").Get<MailKitOptionDto>() ?? new();

    }

    public async Task SendEmailAsync(EmailSendDto dto)
    {
        var email = new MimeMessage();

        email.Sender = MailboxAddress.Parse(_configurationDto.Mail);
        email.To.Add(MailboxAddress.Parse(dto.ToEmail));

        email.Subject = dto.Subject;




        var builder = new BodyBuilder();


        if (dto.Attachments != null && dto.Attachments.Count > 0)
        {
            foreach (var attachment in dto.Attachments)
            {
                if (attachment.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await attachment.CopyToAsync(ms);
                        builder.Attachments.Add(attachment.FileName, ms.ToArray(), ContentType.Parse(attachment.ContentType));
                    }
                }
            }
        }

        builder.HtmlBody = dto.Body;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();

        smtp.Connect(_configurationDto.Host, int.Parse(_configurationDto.Port), SecureSocketOptions.StartTls);
        smtp.Authenticate(_configurationDto.Mail, _configurationDto.Password);

        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);

    }
}
