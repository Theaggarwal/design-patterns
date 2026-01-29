using System;

// Proxy pattern: control access to a resource (e.g., remote StudentService)

namespace ProxyPatternDemo
{
    interface IStudentService { string GetStudentName(int id); }

    class RealStudentService : IStudentService
    {
        public string GetStudentName(int id) => $"Student#{id}"; // pretend this is expensive
    }

    class StudentServiceProxy : IStudentService
    {
        private RealStudentService? _real;
        private readonly bool _allow;
        public StudentServiceProxy(bool allow) { _allow = allow; }
        public string GetStudentName(int id)
        {
            if (!_allow) return "Access Denied";
            _real ??= new RealStudentService();
            return _real.GetStudentName(id);
        }
    }

    class Program
    {
        static void Main()
        {
            IStudentService blocked = new StudentServiceProxy(false);
            IStudentService allowed = new StudentServiceProxy(true);
            Console.WriteLine(blocked.GetStudentName(1));
            Console.WriteLine(allowed.GetStudentName(1));
        }
    }
}
