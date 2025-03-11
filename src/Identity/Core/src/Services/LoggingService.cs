using Microsoft.Extensions.Logging;

public class LoggingService
{
    private readonly ILogger<LoggingService> _logger;

    public LoggingService(ILogger<LoggingService> logger)
    {
        _logger = logger;
    }

    public void LogLoginAttempt(string userId)
    {
        _logger.LogInformation($"Login attempt for user: {userId}");
    }
}
