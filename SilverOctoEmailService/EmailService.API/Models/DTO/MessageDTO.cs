namespace EmailService.API.Models.DTO;

public class MessageDTO
{
    public string ReceiverEmail { get; set; }
    public string ReceiverName { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}