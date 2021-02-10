using Microsoft.Extensions.Logging;
using System;

using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch11
{
    public class ConsoleLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState? state, Exception? exception, Func<TState, Exception, string> formatter)
        {
            if (eventId.Id == 20100)
            {
                Write($"Level: {logLevel}, Event ID: {eventId.Id}, Event: {eventId.Name}");
            }
            if (state != null)
            {
                Write($", State: {state}");
            }
            if (exception != null)
            {
                Write($", Exception: {exception.Message}");
            }
            WriteLine();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Information:
                case LogLevel.None:
                    return false;
                default:
                    return true;
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}