using Microsoft.AspNetCore.Mvc;
using SilverOctoEmailService.Models;
using SilverOctoEmailService.Service;

namespace SilverOctoEmailService.Controllers;

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
                Receiver = message.Receiver,
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