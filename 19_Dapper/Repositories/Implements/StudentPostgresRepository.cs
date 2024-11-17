using _19_Dapper.Helpers;
using _19_Dapper.Models;
using _19_Dapper.Repositories.Abstractions;
using System.Data;

namespace _19_Dapper.Repositories.Implements;

class StudentPostgresRepository : IStudentPostgresRepository
{
    public int Create(Student student)
    {
        string query = $"INSERT INTO Students(Name, Surname, GroupName) VALUES ('{student.Name}', '{student.Surname}', '{student.GroupName}')";
        int affRow = PostgresHelper.Exec(query);

        return affRow;
    }

    public int Delete(int id)
    {
        string query = $"DELETE FROM Students WHERE Id = {id}";
        int affRow = PostgresHelper.Exec(query);

        if (affRow == 0)
        {
            throw new Exception("No student with that id");
        }

        return affRow;
    }

    public Student GetById(int id)
    {
        string query = $"SELECT * FROM Students WHERE Id = {id}";
        DataTable dt = new DataTable();
        Student student = new Student();
        dt = PostgresHelper.Read(query);
        if (dt.Rows.Count == 0)
        {
            throw new Exception("Not student with that id");
        }

        foreach (DataRow dr in dt.Rows)
        {
            student = new Student
            {
                Name = dr["Name"].ToString()!,
                Surname = dr["Surname"].ToString()!,
                GroupName = dr["GroupName"].ToString()!
            };
        }

        return student;
    }

    public List<Student> GetAll()
    {
        DataTable dt = PostgresHelper.Read("SELECT * FROM Students");
        List<Student> students = [];
        foreach (DataRow dr in dt.Rows)
        {
            students.Add(new Student
            {
                Name = dr["Name"].ToString()!,
                Surname = dr["Surname"].ToString()!,
                GroupName = dr["GroupName"].ToString()!
            });
        }
        return students;
    }

    public int Update(int id, Student newStudent)
    {
        string query = $"UPDATE Students SET Name = '{newStudent.Name}', Surname = '{newStudent.Surname}', GroupName = '{newStudent.GroupName}' WHERE Id = {id}";

        int res = PostgresHelper.Exec(query);
        if (res == 0)
        {
            throw new Exception("No student with this id");
        }

        return res;
    }
}
