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
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");


            //SqlConnection mySqlConnection =new SqlConnection(connectionString);

            //string SelString = "SELECT Name, LastName " + "FROM Persons ";
            //SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            //mySqlCommand.CommandText = SelString;
            //SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            //mySqlDataAdapter.SelectCommand = mySqlCommand;
            //DataSet myDataSet = new DataSet();
            //mySqlConnection.Open();
            //string dataTableName = "Persons";
            //mySqlDataAdapter.Fill(myDataSet, dataTableName);
            //DataTable myDataTable = myDataSet.Tables[dataTableName];
            //foreach (DataRow myDataRow in myDataTable.Rows)
            //{
            //    Console.WriteLine("Name = " + myDataRow["Name"]);
            //    Console.WriteLine("LastName = " + myDataRow["LastName"]);
            //}
            //mySqlConnection.Close();



            Console.Write("Name=");
            var name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("LastName=");
            var lastname = Console.ReadLine();
            DateTime BirthDate = new DateTime(1990, 1, 2);
            Console.WriteLine(BirthDate.ToString());

            using (var con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("addperson", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@LastName", lastname);
                cmd.Parameters.AddWithValue("@BirthDate", BirthDate);

                SqlParameter parm3 = new SqlParameter("@result", SqlDbType.NVarChar, size: 100);
                parm3.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parm3);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine(cmd.Parameters["@result"].Value);
            }




        }
    }
}
