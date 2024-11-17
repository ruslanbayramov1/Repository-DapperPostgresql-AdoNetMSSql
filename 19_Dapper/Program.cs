using _19_Dapper.Models;
using _19_Dapper.Repositories.Abstractions;
using _19_Dapper.Repositories.Implements;

namespace _19_Dapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentPostgresDapperRepository stRep = new StudentPostgresDapperRepository();

            stRep.Create(new Student
            {
                Name = "Jack",
                Surname = "Jackson",
                GroupName = "PWT581",
            });

            stRep.Create(new Student
            {
                Name = "Angelie",
                Surname = "Melonie",
                GroupName = "VXK143",
            });

            Console.ReadLine();
            stRep.GetAll().ForEach(x => Console.WriteLine(x.Name));

            Console.ReadLine();
            Console.WriteLine(stRep.GetById(2).Name);

            Console.ReadLine();
            stRep.Update(1, new Student
            {
                Name = "Jackie"
            });

            Console.ReadLine();
            stRep.Delete(1);

            Console.ReadLine();
            stRep.GetAll().ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
