using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            //new Proc().Run();
            //new Select().Run();


            //var x = new Students();
            //x.StudentId = 9;
            //x.F_Name = "asda";
            //x.L_Name = "asdada";
            //StudentsData stud = new StudentsData();

            //stud.insertstud(x);

            //stud.deletestud(x.StudentId);

            //stud.Updatestud(x);

            //Console.WriteLine(new StudentsData().selectStudent(4).StudentId);
            //Console.WriteLine(new StudentsData().selectStudent(4).F_Name);
            //Console.WriteLine(new StudentsData().selectStudent(4).L_Name);
            //Console.WriteLine(new StudentsData().selectStudent(4).BirthDate);

            // for ( int i = 0; i < new StudentsData().GetStudents().Count; i++)
            //Console.WriteLine(new StudentsData().GetStudents());

            var result = new StudentsData().GetStudents();
            foreach (var i in result)
            {
                Console.WriteLine(i.StudentId);
                Console.WriteLine(i.F_Name);
                Console.WriteLine(i.L_Name);
                Console.WriteLine(i.Phone);
                Console.WriteLine(i.BirthDate);
            }
        }
    }
}
