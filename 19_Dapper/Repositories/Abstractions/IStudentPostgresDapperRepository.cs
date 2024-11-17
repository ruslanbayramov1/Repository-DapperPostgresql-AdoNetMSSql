using _19_Dapper.Models;

namespace _19_Dapper.Repositories.Abstractions;

interface IStudentPostgresDapperRepository
{
    List<Student> GetAll();
    Student GetById(int id);
    void Create(Student student);
    void Delete(int id);
    void Update(int id, Student newStudent);
}
