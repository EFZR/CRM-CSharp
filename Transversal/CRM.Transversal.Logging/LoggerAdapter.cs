using Microsoft.Extensions.Logging;
using CRM.Transversal.Common;

namespace CRM.Transversal.Logging;

public class LoggerAdapter<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }
    public void LogError(string message, params object[] args)
    {
        _logger.LogError(message);
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message);
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message);
    }
}
