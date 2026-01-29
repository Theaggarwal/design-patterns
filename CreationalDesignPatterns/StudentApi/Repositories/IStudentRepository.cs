using CreationalDesignPatterns.StudentApi.Models;

namespace CreationalDesignPatterns.StudentApi.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? Get(Guid id);
        void Add(Student student);
        bool Delete(Guid id);
    }
}
