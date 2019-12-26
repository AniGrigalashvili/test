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
        public void insertstud(Students stud)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");


            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            string sqlQuery = string.Format("Insert into Students (StudentId,F_Name ,L_Name) " + 
                              "Values('{0}','{1}' ,'{2}');",
                              stud.StudentId, stud.F_Name, stud.L_Name);
  

            mySqlConnection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, mySqlConnection);

            command.ExecuteNonQuery();

            mySqlConnection.Close();

        }
        public bool deletestud(int StudentId)
        {
            bool result = false;
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

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
            
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

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
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            Students result = new Students();

            string sqlQuery = String.Format("select * from Students where StudentId = {0}", StudentId);

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

    }
}
