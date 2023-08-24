using System.Collections.Generic;

namespace LINQ
{
    public class LinqQueries
    {
        public List<Book> bookCollection { get; set; } = new List<Book>();
        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                bookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
            }

        }
        public IEnumerable<Book> WholeCollection()
        {
            return bookCollection;
        }

        public IEnumerable<Book> BooksMoreThan250Pages(string partTitle){
            // Explicit
            // return from book in bookCollection
            //         where book.PageCount > 250 && book.Title.Contains(partTitle)
            //         select book;

            //Implicit
            return bookCollection.Where(book => book.PageCount>250 && book.Title.Contains(partTitle) );
        }

    }





}