using System;

// Private Class Data (a refactoring / encapsulation technique): keep mutable data in a private helper
// to control access and provide validation points.

namespace PrivateClassDataDemo
{
    class Student
    {
        private class Data
        {
            public string Name = string.Empty;
            public int Age;
        }

        private readonly Data _data = new();

        public string Name
        {
            get => _data.Name;
            set => _data.Name = value ?? string.Empty;
        }

        public int Age
        {
            get => _data.Age;
            set => _data.Age = value < 0 ? 0 : value;
        }

        public override string ToString() => $"{Name} ({Age})";
    }

    class Program
    {
        static void Main()
        {
            var s = new Student();
            s.Name = "Paul";
            s.Age = -5; // invalid, setter will sanitize
            Console.WriteLine(s);
        }
    }
}
