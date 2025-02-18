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
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog]";
                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);

                }
            }

        }

        public void Create(string title, string author, string content)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                String Query = @"
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

                var result = db.Execute(Query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content

                });
                Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed"
);


            }



        }

        public void Edit(int id)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"SELECT [BlogId]
              ,[BlogTitle]
              ,[BlogAuthor]
              ,[BlogContent]
              ,[DeleteFlag]
                FROM [dbo].[Tbl_Blog] where deleteFlag=0  and [BlogId]=@BlogId";
                var item = db.Query<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId= id
                }).FirstOrDefault();

                if (item == null)
                {
                    Console.WriteLine("No Data Found");
                    return;
                }
           
                
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);

                
            }

        }
        public void Update()
        {

            Console.WriteLine("BlogId");
            string id =Console.ReadLine();
            Console.WriteLine("BlogTitle");
            string title = Console.ReadLine();
            Console.WriteLine("BlogAuthor");
            string author = Console.ReadLine();
            Console.WriteLine("BlogContent");
            string content = Console.ReadLine();


            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               

                String Query = @"UPDATE [dbo].[Tbl_Blog]
               SET [BlogTitle] =@BlogTitle
             ,[BlogAuthor] = @BlogAuthor
            ,[BlogContent] = @BlogContent
           ,[DeleteFlag] = 0
           WHERE [BlogId] =@BlogId";

                var result = db.Execute(Query, new BlogDataModel
                {
                    BlogId = Convert.ToInt32(id),
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content


                });






                Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed"
);


            }



        }


        public void Delete()
        {

            Console.WriteLine("BlogId");
            string id = Console.ReadLine();
      

            using (IDbConnection db = new SqlConnection(_connectionString))
            { 

                String Query = @"DELETE FROM [dbo].[Tbl_Blog]
                WHERE [BlogId]=@BlogId";

                var result = db.Execute(Query, new BlogDataModel
                {
                    BlogId = Convert.ToInt32(id)
                    


                });



                Console.WriteLine(result == 1 ? "Delete Successful" : "Delete Failed"
);


            }



        }



    }
}
