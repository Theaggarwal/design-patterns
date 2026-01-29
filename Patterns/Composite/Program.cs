using System;
using System.Collections.Generic;

// Composite pattern: treat individual objects and compositions uniformly.

namespace CompositePatternDemo
{
    interface IComponent { void Display(string indent = ""); }

    class StudentLeaf : IComponent
    {
        private readonly string _name;
        public StudentLeaf(string name) { _name = name; }
        public void Display(string indent = "") => Console.WriteLine(indent + _name);
    }

    class Group : IComponent
    {
        private readonly string _name;
        private readonly List<IComponent> _children = new();
        public Group(string name) { _name = name; }
        public void Add(IComponent c) => _children.Add(c);
        public void Display(string indent = "")
        {
            Console.WriteLine(indent + _name);
            foreach (var c in _children) c.Display(indent + "  ");
        }
    }

    class Program
    {
        static void Main()
        {
            var classA = new Group("Class A");
            classA.Add(new StudentLeaf("Hank"));
            classA.Add(new StudentLeaf("Ivy"));

            var batch = new Group("Batch 2026");
            batch.Add(classA);
            batch.Add(new StudentLeaf("Jack"));

            batch.Display();
        }
    }
}
