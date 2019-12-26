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
    public class Proc
    {
        public void Run()
        {

            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");



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
