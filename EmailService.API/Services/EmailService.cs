using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using SilverOctoEmailService.Models;

namespace SilverOctoEmailService.Service;
public class EmailService : IEmailService
{
    private readonly EmailOptions _emailOptions;

    public EmailService(IOptions<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }
    public void Send(Email mail)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("Sender Name", _emailOptions.EmailSender));
        email.To.Add(new MailboxAddress("Receiver Name", mail.Receiver));

        email.Subject = mail.Subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { 
            Text = mail.Body
        };

        using (var smtp = new SmtpClient())
        {
            smtp.Connect(_emailOptions.SMTPServer, _emailOptions.SMTPPort, false);
            smtp.Authenticate(_emailOptions.UserName, _emailOptions.Password);

            smtp.Send(email);
            smtp.Disconnect(true);
        }

    }
}