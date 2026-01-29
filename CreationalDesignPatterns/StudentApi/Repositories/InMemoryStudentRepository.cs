using CreationalDesignPatterns.StudentApi.Models;

namespace CreationalDesignPatterns.StudentApi.Repositories
{
    // Simple in-memory repository used for demonstration
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new();

        public IEnumerable<Student> GetAll() => _students;

        public Student? Get(Guid id) => _students.FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public bool Delete(Guid id)
        {
            var s = Get(id);
            if (s == null) return false;
            _students.Remove(s);
            return true;
        }
    }
}
