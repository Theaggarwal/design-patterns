using CreationalDesignPatterns.StudentApi.Models;

namespace CreationalDesignPatterns.StudentApi.Repositories
{
    // Factory Method pattern: Creator defines FactoryMethod, concrete creators return specific repositories
    public abstract class RepositoryCreator
    {
        public abstract IStudentRepository FactoryMethod();
    }

    // Concrete creator for InMemory repository
    public class InMemoryRepositoryCreator : RepositoryCreator
    {
        public override IStudentRepository FactoryMethod()
        {
            // Could encapsulate complex creation logic here
            return new InMemoryStudentRepository();
        }
    }

    // Placeholder for another concrete creator (e.g., EF Core)
    public class EfRepositoryCreator : RepositoryCreator
    {
        public override IStudentRepository FactoryMethod()
        {
            // Return EF-backed repo (not implemented in this demo)
            throw new NotImplementedException("EF repository not implemented in demo");
        }
    }
}
