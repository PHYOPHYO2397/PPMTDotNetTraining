// See https://aka.ms/new-console-template for more information
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

string connectionString = "Data Source=DESKTOP-3HK6N3Q;Initial Catalog=PPMTDotNetTrainingBatch5;User ID=DESKTOP-3HK6N3Q￥yukin";
Console.WriteLine(connectionString);
SqlConnection connection = new SqlConnection(connectionString);
//Reason is coz of max connection number
//To prevent connection timeout error
Console.WriteLine(value: "Connection opening...");
connection.Open();
Console.WriteLine(value: "Connection Opened...");
Console.WriteLine(value: "Connection Closing...");
connection.Close();
Console.WriteLine(value: "Connection Closed...");
Console.ReadKey();

