using System;
using System.Collections.Generic;

// Abstract Factory pattern: creational design pattern. states - provides an interface for creating families of related or dependent objects without specifying their concrete classes. 
// Here we create families of repositories and loggers for different environments.

namespace AbstractFactoryDemo
{
    interface IStudentRepository { IEnumerable<string> GetAllNames(); }
    interface ILogger { void Log(string msg); }

    // Windows-style family
    class WinRepo : IStudentRepository { public IEnumerable<string> GetAllNames() => new[] { "Win-Alice", "Win-Bob" }; }
    class WinLogger : ILogger { public void Log(string msg) => Console.WriteLine("[WinLogger] " + msg); }

    // Mac-style family
    class MacRepo : IStudentRepository { public IEnumerable<string> GetAllNames() => new[] { "Mac-Alice", "Mac-Bob" }; }
    class MacLogger : ILogger { public void Log(string msg) => Console.WriteLine("[MacLogger] " + msg); }

    interface IGuiFactory { IStudentRepository CreateRepo(); ILogger CreateLogger(); }

    class WinFactory : IGuiFactory { public IStudentRepository CreateRepo() => new WinRepo(); public ILogger CreateLogger() => new WinLogger(); }
    class MacFactory : IGuiFactory { public IStudentRepository CreateRepo() => new MacRepo(); public ILogger CreateLogger() => new MacLogger(); }

    class Program
    {
        static void Main()
        {
            IGuiFactory factory = new WinFactory();
            var repo = factory.CreateRepo();
            var logger = factory.CreateLogger();
            foreach (var n in repo.GetAllNames()) logger.Log(n);

            factory = new MacFactory();
            repo = factory.CreateRepo();
            logger = factory.CreateLogger();
            foreach (var n in repo.GetAllNames()) logger.Log(n);
        }
    }
}
