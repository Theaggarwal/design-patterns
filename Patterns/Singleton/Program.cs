using System;

// Singleton pattern example: a class has only one instance and provides a global access point to it.
// Study this folder to see a minimal, thread-safe Singleton implementation.

namespace SingletonPatternDemo
{
    // Lock-based singleton (double-check locking).
    // This demonstrates an alternative to Lazy<T> using `lock` and `volatile` for thread-safety.
    sealed class Logger
    {
        // `volatile` ensures the read/write to the reference is not reordered by the compiler/runtime.
        private static volatile Logger? _instance;
        private static readonly object _sync = new();

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

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
