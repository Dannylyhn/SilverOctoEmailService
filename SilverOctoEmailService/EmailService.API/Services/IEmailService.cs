using EmailService.API.Models;

namespace EmailService.API.Services;

public interface IEmailService
{
    public void Send(Email email);
}