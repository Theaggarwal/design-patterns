# CreationalDesignPatterns - Student API

This folder contains a small .NET 9 Web API (`StudentApi`) that implements a Student Management example and demonstrates several Gang of Four creational patterns:

- Singleton: `LoggerSingleton`
- Factory Method: `StudentRepositoryFactory` with `InMemoryRepositoryCreator`
- Builder: `StudentBuilder` for constructing `Student` objects
- Prototype: `Student` implements `ICloneable` for cloning

Run the API with:

```bash
dotnet run --project CreationalDesignPatterns/StudentApi
```

Example endpoints (after start):
- `GET /students`
- `GET /students/{id}`
- `POST /students` (JSON body)
- `POST /students/{id}/clone` (creates a clone of a student)

The code includes inline comments describing how each pattern maps to the implementation.
