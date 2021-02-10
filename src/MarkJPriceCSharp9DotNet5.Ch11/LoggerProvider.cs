using Microsoft.Extensions.Logging;

namespace MarkJPriceCSharp9DotNet5.Ch11
{
    public class LoggerProvider : ILoggerProvider
    {
        public void Dispose() { }

        public ILogger CreateLogger(string categoryName) => new ConsoleLogger();
    }
}