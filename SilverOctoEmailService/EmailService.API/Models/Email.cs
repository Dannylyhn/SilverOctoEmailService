namespace EmailService.API.Models;

public class Email
{
    public Guid Guid { get; set; }
    public string ReceiverEmail { get; set; }
    public string ReceiverName { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}