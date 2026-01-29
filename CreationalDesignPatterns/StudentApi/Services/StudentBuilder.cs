using CreationalDesignPatterns.StudentApi.Models;

namespace CreationalDesignPatterns.StudentApi.Services
{
    // Builder pattern: construct Student step by step
    public class StudentBuilder
    {
        private Student _student = new();

        public StudentBuilder SetName(string name)
        {
            _student.Name = name;
            return this;
        }

        public StudentBuilder SetAge(int age)
        {
            _student.Age = age;
            return this;
        }

        public StudentBuilder SetEmail(string email)
        {
            _student.Email = email;
            return this;
        }

        public Student Build()
        {
            var result = _student;
            _student = new Student();
            return result;
        }
    }
}
