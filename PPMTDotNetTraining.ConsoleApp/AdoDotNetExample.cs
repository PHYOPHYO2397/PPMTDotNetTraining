using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMTDotNetTraining.ConsoleApp
{
    public class AdoDotNetExample
    {

        private readonly string _connectionString= "Data Source=DESKTOP-3HK6N3Q;Initial Catalog=PPMTDotNetTraining;User ID=sa;Password=sasa@123";


        public void Read()
        {
            
            Console.WriteLine(_connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine(value: "Connection opening...");
            connection.Open();
            Console.WriteLine(value: "Connection Opened...");

            string query = @"SELECT [BlogId]
          ,[BlogTitle]
          ,[BlogAuthor]
          ,[BlogContent]
          ,[DeleteFlag]
          FROM [dbo].[Tbl_Blog] where DeleteFlag=0";

            SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
                Console.WriteLine(reader["BlogId"]);
            }




            Console.WriteLine(value: "Connection Closing...");
            connection.Close();
            Console.WriteLine(value: "Connection Closed...");
            Console.ReadKey();
        }
     }

    
}
