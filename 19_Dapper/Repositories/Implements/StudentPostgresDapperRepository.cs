using _19_Dapper.Helpers;
using _19_Dapper.Models;
using _19_Dapper.Repositories.Abstractions;
using Dapper;
using Npgsql;

namespace _19_Dapper.Repositories.Implements;

class StudentPostgresDapperRepository : IStudentPostgresDapperRepository
{
    
    public void Create(Student student)
    {
        string query = $"INSERT INTO Students(Name, Surname, GroupName) VALUES ('{student.Name}', '{student.Surname}', '{student.GroupName}')";
        PostgresDapperHelper.Exec(query);
    }

    public void Delete(int id)
    {
        string query = $"DELETE FROM Students WHERE Id = {id}";
        PostgresDapperHelper.Exec(query);
    }

    public List<Student> GetAll()
    {
        string query = $"SELECT * FROM Students";
        List<Student> students= PostgresDapperHelper.Read<Student>(query);
        return students;
    }

    public Student GetById(int id)
    {
        string query = $"SELECT * FROM Students WHERE Id = {id}";
        Student student = PostgresDapperHelper.ReadSingle<Student>(query);
        return student;
    }

    public void Update(int id, Student newStudent)
    {
        string query = $"UPDATE Students SET Name = '{newStudent.Name}', Surname = '{newStudent.Surname}', GroupName = '{newStudent.GroupName}' WHERE Id = {id}";
        PostgresDapperHelper.Exec(query);
    }
}
