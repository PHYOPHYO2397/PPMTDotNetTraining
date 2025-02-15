using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PPMTDotNetTraining.ConsoleApp.Models;

namespace PPMTDotNetTraining.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=DESKTOP-3HK6N3Q;Initial Catalog=PPMTDotNetTraining;User ID=sa;Password=sasa@123";

        public void Read()
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            { string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog]";
               var lst= db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst) {
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);

                }
            }

        }
    }
}
