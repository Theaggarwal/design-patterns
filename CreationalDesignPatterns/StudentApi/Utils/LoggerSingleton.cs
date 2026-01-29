using System;

namespace CreationalDesignPatterns.StudentApi.Utils
{
    // Singleton pattern: single Logger instance used across the app
    public class LoggerSingleton
    {
        private static readonly Lazy<LoggerSingleton> _instance = new(() => new LoggerSingleton());
        public static LoggerSingleton Instance => _instance.Value;

        // Private ctor prevents external instantiation
        private LoggerSingleton() { }

        public void Log(string message)
        {
            Console.WriteLine($"[Logger] {DateTime.UtcNow:o} - {message}");
        }
    }
}
