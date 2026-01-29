using System;

// Adapter pattern: adapt an existing Adaptee to the IStudentPrinter interface.

namespace AdapterPatternDemo
{
    class Adaptee
    {
        public void PrintDetails(string name, int age) => Console.WriteLine($"Adaptee prints: {name} ({age})");
    }

    interface IStudentPrinter { void Print(Student s); }

    class Student { public string Name { get; set; } = ""; public int Age { get; set; } }

    // Adapter wraps Adaptee and exposes IStudentPrinter
    class StudentPrinterAdapter : IStudentPrinter
    {
        private readonly Adaptee _adaptee = new();
        public void Print(Student s) => _adaptee.PrintDetails(s.Name, s.Age);
    }

    class Program
    {
        static void Main()
        {
            var student = new Student { Name = "Eve", Age = 21 };
            IStudentPrinter printer = new StudentPrinterAdapter();
            printer.Print(student);
        }
    }
}
