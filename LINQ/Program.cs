using LINQ;
using Dapper;
using practiceDapper;
using System.Data;
using System.Data.SqlClient;
using problem;

// LinqQueries collectionQueries = new LinqQueries();

// Problem p = new Problem();

// p.displayShortestPath();

Solution sol = new Solution();
int[][] edges = {
           new int[] {0,1},
           new int[] {1,2},
           new int[] {0,2},
        };


double[] props = {
           0.5,
           0.5,
           0.2,
        };

Console.WriteLine(sol.MaxProbability(3,edges,props,0,2));

// void PrintValues(IEnumerable<Book> booksList)
// {
//     Console.WriteLine("{0,-70} {1,7} {2,11}\n", "Title", "N. Pages", "Publish Date");
//     foreach (var item in booksList)
//     {
//         Console.WriteLine("{0,-70} {1,7} {2,11}\n", item.Title, item.PageCount, item.PublishedDate);

//     }

// }

// // using (IDbConnection connection = new SqlConnection(
// //     "Data Source=.\\;User=myUser;Password=user;Database=AdventureWorks2022;TrustServerCertificate=True"))
// // {
// //     var people = connection.Query<Person>("select * from  Person.Person"); // IENumerable<Person> linq
// //     var peoplev2 = await connection.QueryAsync<Person>("select * from Person.Person");
// //     foreach(var p in peoplev2){
// //         Console.WriteLine($"Hello {p.FirstName}");
// //     }
    
// // }

// //Print whole collection
// // PrintValues(collectionQueries.WholeCollection());

// // Print books more than 250 pages
// PrintValues(collectionQueries.BooksMoreThan250Pages("Java"));

// Print if all the books have status
// Console.WriteLine(collectionQueries.AllBooksHasStatus());
//Console.WriteLine(collectionQueries.IsThereAPublishedBookIn2005());
// PrintValues(collectionQueries.BooksCategoryJavaTop5Skip2());
// PrintValues(collectionQueries.BooksTitlesNotAvaible());

