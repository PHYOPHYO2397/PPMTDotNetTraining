﻿// See https://aka.ms/new-console-template for more information
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
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("Dapper", "Dapper", "Dapper");
//dapperExample.Edit(2);
//dapperExample.Edit(20000);
//dapperExample.Update();
dapperExample.Delete();


Console.ReadKey();

