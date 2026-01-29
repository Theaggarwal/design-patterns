using System;

// Decorator pattern: dynamically add behavior to a component. Here we decorate a StudentPrinter.

namespace DecoratorPatternDemo
{
    interface IStudentPrinter { void Print(string name); }

    class BasicPrinter : IStudentPrinter { public void Print(string name) => Console.WriteLine(name); }

    abstract class PrinterDecorator : IStudentPrinter
    {
        protected IStudentPrinter _inner;
        protected PrinterDecorator(IStudentPrinter inner) { _inner = inner; }
        public abstract void Print(string name);
    }

    class TimestampDecorator : PrinterDecorator
    {
        public TimestampDecorator(IStudentPrinter inner) : base(inner) { }
        public override void Print(string name) { Console.Write($"[{DateTime.UtcNow:o}] "); _inner.Print(name); }
    }

    class UppercaseDecorator : PrinterDecorator
    {
        public UppercaseDecorator(IStudentPrinter inner) : base(inner) { }
        public override void Print(string name) => _inner.Print(name.ToUpperInvariant());
    }

    class Program
    {
        static void Main()
        {
            IStudentPrinter printer = new UppercaseDecorator(new TimestampDecorator(new BasicPrinter()));
            printer.Print("frank");
        }
    }
}
