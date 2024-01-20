using SilverOctoEmailService.Models;

namespace SilverOctoEmailService.Service;

public interface IEmailService
{
    public void Send(Email email);
}