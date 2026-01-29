using System;

namespace CreationalDesignPatterns.StudentApi.Models
{
    // Prototype pattern: Student implements ICloneable to allow creating copies
    public class Student : ICloneable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;

        public object Clone()
        {
            // Deep copy (simple for primitive properties)
            return new Student
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age,
                Email = this.Email
            };
        }
    }
}
