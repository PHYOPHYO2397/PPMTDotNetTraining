// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//C# and Database Connection
//ADO.NET
//Dapper(ORM)
//EF Core
//Entity Framework(ORM)
//Object Relational Mapping
//C# → SQL Query
//nuget package


//Create SQL connection
//Crtl +.


string connectionString = "Data Source=DESKTOP-3HK6N3Q;Initial Catalog=PPMTDotNetTraining;User ID=sa;Password=sasa@123";
Console.WriteLine(connectionString);
SqlConnection connection = new SqlConnection(connectionString);
Console.WriteLine(value: "Connection opening...");
connection.Open();
Console.WriteLine(value: "Connection Opened...");

string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag=0";

SqlCommand cmd = new SqlCommand(query,connection);
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


//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//    Console.WriteLine(dr["BlogId"]);

//}

Console.Write("Blog Title:");
string title = Console.ReadLine();

Console.Write("Blog Author:");

string author = Console.ReadLine();


Console.Write("Blog Content:");
string content= Console.ReadLine();



string connectionString2 = "Data Source=DESKTOP-3HK6N3Q;Initial Catalog=PPMTDotNetTraining;User ID=sa;Password=sasa@123";
SqlConnection connection2 = new SqlConnection(connectionString2);
connection2.Open();
String Query2 = $@"
INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}'
           ,0)";
SqlCommand cmd2 =new SqlCommand(Query2,connection2);
SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
DataTable dt = new DataTable();
adapter.Fill(dt);
connection2.Close();


