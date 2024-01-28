using EmailService.API.Models;
using EmailService.API.Models.DTO;
using EmailService.API.Services;
using Microsoft.AspNetCore.Mvc;
namespace EmailService.API.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class EmailServiceController : ControllerBase
{
    private IEmailService _emailService;
    private ILogger<EmailServiceController> _logger;

    public EmailServiceController(IEmailService emailService,
        ILogger<EmailServiceController> logger)
    {
        _emailService = emailService;
        _logger = logger;
    }

    [HttpPost("SendEmail")]
    public async Task<IActionResult> SendEmail(MessageDTO message)
    {
        var guid = new Guid();
        try
        {
            _emailService.Send(new Email
            {
                Guid = guid,
                ReceiverEmail = message.ReceiverEmail,
                ReceiverName = message.ReceiverName,
                Subject = message.Subject,
                Body = message.Message
            });
            return Ok(guid);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, $"Error while processing the request {guid}");
            return StatusCode(500);
        }
    }
}