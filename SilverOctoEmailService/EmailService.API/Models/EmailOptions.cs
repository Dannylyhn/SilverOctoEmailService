namespace EmailService.API.Models;

public class EmailOptions
{
    public string EmailSender { get; set; }
    public string SenderName { get; set; }
    public string SMTPServer { get; set; }
    public int SMTPPort { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}