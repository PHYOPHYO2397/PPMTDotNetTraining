// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using PPMTDotNetTraining.ConsoleApp;


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

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();



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

//BAD example
//SQL Injection can occur

//String Query2 = $@"
//INSERT INTO [dbo].[Tbl_Blog]
//           ([BlogTitle]
//           ,[BlogAuthor]
//           ,[BlogContent]
//           ,[DeleteFlag])
//     VALUES
//           ('{title}'
//           ,'{author}'
//           ,'{content}'
//           ,0)";

String Query2 = @"
INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle,
           @BlogAuthor,
           @BlogContent,
0)";




SqlCommand cmd2 = new SqlCommand(Query2, connection2);
cmd2.Parameters.AddWithValue("@BlogTitle",title);
cmd2.Parameters.AddWithValue("@BlogAuthor", author);
cmd2.Parameters.AddWithValue("@BlogContent", content);
int result = cmd2.ExecuteNonQuery();
connection2.Close();
//if (result ==1)
//{
//    Console.WriteLine("Saving Successful");
//}
//else
//{
//    Console.WriteLine("Saving Failed");
//}

//Ternary Operator
Console.WriteLine(result==1?"Saving Successful":"Saving Failed");
