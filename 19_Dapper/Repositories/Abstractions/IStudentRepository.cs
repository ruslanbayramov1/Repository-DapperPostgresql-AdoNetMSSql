using _19_Dapper.Models;

namespace _19_Dapper.Repositories.Abstractions;

interface IStudentRepository
{
    List<Student> GetAll();
    Student GetById(int id);
    int Create(Student student);
    int Delete(int id);
    int Update(int id, Student newStudent);
}
