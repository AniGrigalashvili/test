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
    public class Select
    {
        public void Run()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");


            SqlConnection mySqlConnection = new SqlConnection(connectionString);

            string SelString = "SELECT Name, LastName " + "FROM Persons ";
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = SelString;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataSet myDataSet = new DataSet();
            mySqlConnection.Open();
            string dataTableName = "Persons";
            mySqlDataAdapter.Fill(myDataSet, dataTableName);
            DataTable myDataTable = myDataSet.Tables[dataTableName];
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("Name = " + myDataRow["Name"]);
                Console.WriteLine("LastName = " + myDataRow["LastName"]);
            }
            mySqlConnection.Close();
        }
    }
}
