using Mhd.Framework.Grpc.Common;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Sample.Grpc.Server
{
    public class LogProvider : ILogProvider
    {
        private readonly ILogger<LogProvider> _logger;
        public LogProvider(ILogger<LogProvider> logger)
            => _logger = logger;

        public Task WriteLogAsync(WebServiceLog webServiceLog)
        {
            //var correlationId = webServiceLog.CorrelationId;

            // webServiceLog includes request and response.

            return Task.CompletedTask;
        }
    }
}
