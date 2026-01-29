using CreationalDesignPatterns.StudentApi.Models;
using CreationalDesignPatterns.StudentApi.Repositories;
using CreationalDesignPatterns.StudentApi.Services;
using CreationalDesignPatterns.StudentApi.Utils;

var builder = WebApplication.CreateBuilder(args);

// Use Factory Method to create repository creator (choose InMemory for demo)
RepositoryCreator repoCreator = new InMemoryRepositoryCreator();
IStudentRepository repository = repoCreator.FactoryMethod();

// Register instances in DI
builder.Services.AddSingleton<IStudentRepository>(repository);
builder.Services.AddSingleton<LoggerSingleton>(LoggerSingleton.Instance);
builder.Services.AddSingleton<StudentBuilder>();

var app = builder.Build();

app.MapGet("/students", (IStudentRepository repo) => Results.Ok(repo.GetAll()));

app.MapGet("/students/{id}", (IStudentRepository repo, Guid id) =>
{
    var s = repo.Get(id);
    return s is null ? Results.NotFound() : Results.Ok(s);
});

app.MapPost("/students", (IStudentRepository repo, StudentBuilder builderModel) =>
{
    // Builder pattern used to construct a Student from partial data (for demo, simple usage)
    var student = builderModel
        .SetName("New Student")
        .SetAge(18)
        .SetEmail("student@example.com")
        .Build();

    repo.Add(student);
    LoggerSingleton.Instance.Log($"Created student {student.Id}");
    return Results.Created($"/students/{student.Id}", student);
});

app.MapPost("/students/{id}/clone", (IStudentRepository repo, Guid id) =>
{
    var s = repo.Get(id);
    if (s == null) return Results.NotFound();
    // Prototype pattern: clone existing student
    var clone = (Student)s.Clone();
    clone.Id = Guid.NewGuid();
    clone.Name += " (Clone)";
    repo.Add(clone);
    LoggerSingleton.Instance.Log($"Cloned student {id} -> {clone.Id}");
    return Results.Created($"/students/{clone.Id}", clone);
});

app.MapDelete("/students/{id}", (IStudentRepository repo, Guid id) =>
{
    var removed = repo.Delete(id);
    return removed ? Results.NoContent() : Results.NotFound();
});

app.Run();
