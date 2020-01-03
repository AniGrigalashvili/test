using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace test
{
    public class StudentsData
    {
        IConfigurationRoot configuration = null;
        string connectionString = "";
        public StudentsData()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void insertstud(Students stud)
        {

            string sqlQuery = string.Format("Insert into Students (StudentId, F_Name, L_Name) " + 
                              "Values('{0}', '{1}', '{2}');",
                              stud.StudentId, stud.F_Name, stud.L_Name);

            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            mySqlConnection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, mySqlConnection);

            command.ExecuteNonQuery();

            mySqlConnection.Close();

        }
        public bool deletestud(int StudentId)
        {
            bool result = false;

            SqlConnection mySqlConnection = new SqlConnection(connectionString);


            string sqlQuery = String.Format("delete from Students where StudentId = {0}", StudentId);

            mySqlConnection.Open();


            SqlCommand command = new SqlCommand(sqlQuery, mySqlConnection);

            int rowsCount = command.ExecuteNonQuery();
            if (rowsCount != 0)
                result = true;

            command.Dispose();
            mySqlConnection.Close();
            mySqlConnection.Dispose();

            return result;
        }



        public void Updatestud(Students stud)
        {

            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            string updateQuery = String.Format("Update Students SET F_Name='{0}', L_Name = '{1}' Where StudentId = {2}",
               stud.F_Name, stud.L_Name, stud.StudentId);



            mySqlConnection.Open();

            SqlCommand command = new SqlCommand(updateQuery, mySqlConnection);

            command.ExecuteNonQuery();

            mySqlConnection.Close();

        }

        public Students selectStudent(int StudentId)
        {
    

            Students result = new Students();

            string sqlQuery = String.Format("select * from Students where StudentId = {0}", StudentId);

            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            mySqlConnection.Open();

            SqlCommand comm = new SqlCommand(sqlQuery, mySqlConnection);

            SqlDataReader dataReader = comm.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    result.StudentId = Convert.ToInt32(dataReader["StudentId"]);
                    result.F_Name = dataReader["F_Name"].ToString();
                    result.L_Name = dataReader["L_Name"].ToString();
                    result.BirthDate = Convert.ToDateTime(dataReader["BirthDate"]);
                    result.Phone = dataReader["Phone"].ToString();
                }
            }

            return result;
        }

        public List<Students> GetStudents()
        {
 
            List<Students> result = new List<Students>();

            string sqlQuery = String.Format("select * from Students");

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
 
            SqlCommand command = new SqlCommand(sqlQuery, connection);


            SqlDataReader dataReader = command.ExecuteReader();

            Students stud = null;

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    stud = new Students();

                    stud.StudentId = Convert.ToInt32(dataReader["StudentId"]);
                    stud.F_Name = dataReader["F_Name"].ToString();
                    stud.L_Name = dataReader["L_Name"].ToString();
                    stud.BirthDate = Convert.ToDateTime(dataReader["BirthDate"]);
                    stud.Phone = dataReader["Phone"].ToString();

                    result.Add(stud);
                }
}
 
            return result;
 
        }

    }
}
