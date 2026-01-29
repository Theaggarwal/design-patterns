using System;
using System.Collections.Generic;

// Factory Method pattern: defines an interface for creating objects but lets subclasses decide which object to instantiate

namespace FactoryMethodDemo
{
    interface IStudentRepository { IEnumerable<string> GetAllNames(); }

    class InMemoryRepository : IStudentRepository
    {
        private readonly List<string> _names = new() { "Alice", "Bob" };
        public IEnumerable<string> GetAllNames() => _names;
    }

    abstract class RepositoryCreator
    {
        public abstract IStudentRepository FactoryMethod();
    }

    class InMemoryCreator : RepositoryCreator
    {
        public override IStudentRepository FactoryMethod() => new InMemoryRepository();
    }

    class Program
    {
        static void Main()
        {
            RepositoryCreator creator = new InMemoryCreator();
            var repo = creator.FactoryMethod();
            foreach (var n in repo.GetAllNames()) Console.WriteLine(n);
        }
    }
}
