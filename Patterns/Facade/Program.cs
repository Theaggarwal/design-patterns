using System;

// Facade pattern: provide a simple interface over a set of subsystems.

namespace FacadePatternDemo
{
    class Registrar { public void Register(string name) => Console.WriteLine($"Registering {name}"); }
    class Billing { public void Charge(string name) => Console.WriteLine($"Charging {name}"); }
    class Notification { public void Notify(string name) => Console.WriteLine($"Notifying {name}"); }

    class EnrollmentFacade
    {
        private readonly Registrar _r = new();
        private readonly Billing _b = new();
        private readonly Notification _n = new();
        public void Enroll(string student)
        {
            _r.Register(student);
            _b.Charge(student);
            _n.Notify(student);
            Console.WriteLine("Enrollment complete.");
        }
    }

    class Program
    {
        static void Main()
        {
            var facade = new EnrollmentFacade();
            facade.Enroll("Olivia");
        }
    }
}
