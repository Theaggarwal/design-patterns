using System;

// Simple Factory pattern: a single Factory class decides which concrete Student to create.

namespace FactoryPatternDemo
{
    abstract class Student { public abstract string Describe(); }
    class ScienceStudent : Student { public override string Describe() => "Science Student"; }
    class ArtsStudent : Student { public override string Describe() => "Arts Student"; }

    static class StudentFactory
    {
        public static Student Create(string type) => type.ToLower() switch
        {
            "science" => new ScienceStudent(),
            "arts" => new ArtsStudent(),
            _ => throw new ArgumentException("Unknown type")
        };
    }

    class Program
    {
        static void Main()
        {
            var s1 = StudentFactory.Create("science");
            var s2 = StudentFactory.Create("arts");
            Console.WriteLine(s1.Describe());
            Console.WriteLine(s2.Describe());
        }
    }
}
