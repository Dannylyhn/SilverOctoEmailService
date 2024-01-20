namespace SilverOctoEmailService.Models;

public class Email
{
    public Guid Guid { get; set; }
    public string Receiver { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}