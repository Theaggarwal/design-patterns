using System;

// Bridge pattern: separate abstraction (Report) from implementation (IRenderer) so they can vary independently.

namespace BridgePatternDemo
{
    interface IRenderer { void Render(string content); }
    class PlainRenderer : IRenderer { public void Render(string content) => Console.WriteLine(content); }
    class HtmlRenderer : IRenderer { public void Render(string content) => Console.WriteLine($"<p>{content}</p>"); }

    abstract class Report
    {
        protected IRenderer Renderer;
        protected Report(IRenderer r) { Renderer = r; }
        public abstract void Display();
    }

    class StudentReport : Report
    {
        private readonly string _content;
        public StudentReport(IRenderer r, string content) : base(r) { _content = content; }
        public override void Display() => Renderer.Render(_content);
    }

    class Program
    {
        static void Main()
        {
            var plain = new StudentReport(new PlainRenderer(), "Student: Gina");
            var html = new StudentReport(new HtmlRenderer(), "Student: Gina");
            plain.Display();
            html.Display();
        }
    }
}
