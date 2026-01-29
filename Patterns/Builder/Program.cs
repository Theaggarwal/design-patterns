using System;

// Builder pattern: create complex Student objects step by step using a dedicated builder class.
// separates the construction process from the object’s representation, enabling the same method to create different variations of an object.

namespace BuilderDemo
{
    class Student
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public override string ToString() => $"{Name}, {Age}, {Email}";
    }

    class StudentBuilder
    {
        private Student _student = new();
        public StudentBuilder SetName(string name) { _student.Name = name; return this; }
        public StudentBuilder SetAge(int age) { _student.Age = age; return this; }
        public StudentBuilder SetEmail(string email) { _student.Email = email; return this; }
        public Student Build() { var r = _student; _student = new Student(); return r; }
    }

    class Program
    {
        static void Main()
        {
            var builder = new StudentBuilder();
            var student = builder.SetName("Charlie").SetAge(20).SetEmail("charlie@example.com").Build();
            Console.WriteLine(student);
        }
    }
}
