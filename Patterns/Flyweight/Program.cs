using System;
using System.Collections.Generic;

// Flyweight pattern: share common (intrinsic) state to reduce memory.

namespace FlyweightPatternDemo
{
    class StudentStyle
    {
        public string Color { get; }
        public StudentStyle(string color) { Color = color; }
    }

    class StudentStyleFactory
    {
        private readonly Dictionary<string, StudentStyle> _cache = new();
        public StudentStyle GetStyle(string color) => _cache.TryGetValue(color, out var s) ? s : (_cache[color] = new StudentStyle(color));
    }

    class Student
    {
        public string Name { get; }
        public StudentStyle Style { get; }
        public Student(string name, StudentStyle style) { Name = name; Style = style; }
        public void Draw() => Console.WriteLine($"{Name} with color {Style.Color} (style hash {Style.GetHashCode()})");
    }

    class Program
    {
        static void Main()
        {
            var factory = new StudentStyleFactory();
            var s1 = new Student("Liam", factory.GetStyle("red"));
            var s2 = new Student("Maya", factory.GetStyle("red"));
            var s3 = new Student("Nina", factory.GetStyle("blue"));
            s1.Draw(); s2.Draw(); s3.Draw();
        }
    }
}
