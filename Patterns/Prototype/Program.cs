using System;

// Prototype pattern: demonstrate shallow vs deep cloning when an object contains a child object.

namespace PrototypeDemo
{
    // Child object referenced by Student. Implements ICloneable so Student can perform deep copies.
    class Address : ICloneable
    {
        public string Street { get; set; } = string.Empty;
        public Address() { }
        public Address(string street) { Street = street; }
        public object Clone() => new Address(Street);
        public override string ToString() => Street;
    }

    class Student : ICloneable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public Address? Address { get; set; }

        // Shallow clone: copies the Student object, but `Address` reference is shared between original and clone.
        public Student ShallowClone()
        {
            return (Student)MemberwiseClone();
        }

        // Deep clone: creates a new Student and clones child objects so they are independent.
        public object Clone()
        {
            return new Student
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age,
                Email = this.Email,
                Address = this.Address is null ? null : (Address)this.Address.Clone()
            };
        }

        public override string ToString()
        {
            return $"{Id} - {Name} ({Age}) - {Email} - Address: {Address}";
        }
    }

    class Program
    {
        static void Main()
        {
            var original = new Student { Name = "Dana", Age = 22, Email = "dana@example.com", Address = new Address("1 Main St") };

            // Demonstrate shallow clone behavior
            var shallow = original.ShallowClone();
            shallow.Id = Guid.NewGuid();
            shallow.Name += " (Shallow)";
            // Modify the child's street on the shallow clone - this will affect the original because Address is shared
            if (shallow.Address != null) shallow.Address.Street = "Changed Street (Shallow)";

            Console.WriteLine("-- After shallow clone and modifying clone.Address --");
            Console.WriteLine("Original: " + original);
            Console.WriteLine("Shallow : " + shallow);

            // Demonstrate deep clone behavior
            var deep = (Student)original.Clone();
            deep.Id = Guid.NewGuid();
            deep.Name += " (Deep)";
            // Modify the child's street on the deep clone - original remains unchanged
            if (deep.Address != null) deep.Address.Street = "Changed Street (Deep)";

            Console.WriteLine();
            Console.WriteLine("-- After deep clone and modifying deep.Address --");
            Console.WriteLine("Original: " + original);
            Console.WriteLine("Deep    : " + deep);
        }
    }
}
