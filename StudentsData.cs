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
        public void insertstud()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");


            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            string sqlQuery = string.Format("Insert into Students (StudentId,F_Name ,L_Name,BirthDate) " + 
                              "Values('6','ani' ,'grigalashvili','1997-1-27');",
                              "Select @@Identity", new Students().StudentId, new Students().F_Name, new Students().L_Name);
  

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



        public void Updatestud(int studID)
        {
            
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            string updateQuery = String.Format("Update Students SET F_Name='{0}', L_Name = '{1}' Where StudentId = {2}",
               new Students().F_Name, new Students().L_Name, new Students().StudentId);



            mySqlConnection.Open();

            SqlCommand command = new SqlCommand(updateQuery, mySqlConnection);

            command.ExecuteNonQuery();

            mySqlConnection.Close();

        }

    }
}
