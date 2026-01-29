using System;

// Singleton pattern example: a single Logger instance used across the application.
// Study this folder to see a minimal, thread-safe Singleton implementation.

namespace SingletonPatternDemo
{
    // Make the Logger sealed to prevent inheritance which could break the singleton guarantee.
    sealed class Logger
    {
        // Explicitly specify thread-safety mode for clarity: ExecutionAndPublication is fully thread-safe.
        private static readonly Lazy<Logger> _instance = new(() => new Logger(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
        public static Logger Instance => _instance.Value;
        private Logger() { }
        public void Log(string message) => Console.WriteLine($"[Logger] {DateTime.UtcNow:o} - {message}");
    }

    class Program
    {
        static void Main()
        {
            var l1 = Logger.Instance;
            var l2 = Logger.Instance;
            l1.Log("First message");
            Console.WriteLine($"Same instance: {ReferenceEquals(l1, l2)}");
        }
    }
}
