namespace project.services.Impl;

using project.services;

public class EmailSenderService : IEmailSenderService
{
  private readonly ILogger<EmailSenderService> _logger;
  private readonly IChatGPTService _chatGptService;

  public EmailSenderService(ILogger<EmailSenderService> logger, IChatGPTService chatGptService)
  {
    _logger = logger;
    _chatGptService = chatGptService;
  }
  public bool SendEmail(string to, string subject, string? body)
  {
    _chatGptService.GetSuggestions("message from chatGpt");
    return true;
  }
}