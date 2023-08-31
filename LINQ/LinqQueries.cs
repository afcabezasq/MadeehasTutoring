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

        public IEnumerable<Book> BooksThatContainBuildingInDesc() {
            return bookCollection.Where(book => book.LongDescription != null && book.LongDescription.Contains("building"));
        }


        public bool AllBooksHasStatus(){
            return bookCollection.All(book => book.Status != string.Empty);
            // [True,False,False]
        }

        public bool IsThereAPublishedBookIn2005(){
            return bookCollection.Any(book => book.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> BooksThatContainBuildingInDescAscingOrder() {
            return bookCollection
                .Where(book => book.LongDescription != null && book.LongDescription.Contains("building"))
                .OrderBy(book => book.PageCount);
        }
        public IEnumerable<Book> BooksThatContainBuildingInDescDescendingOrder() {
            return bookCollection
                .Where(book => book.LongDescription != null && book.LongDescription.Contains("building"))
                .OrderByDescending(book => book.PageCount);
        }

        public IEnumerable<Book> BooksThatContainBuildingInDescDescendingOrderTakeTop4() {
            return bookCollection
                .Where(book => book.LongDescription != null && book.LongDescription.Contains("building"))
                .OrderByDescending(book => book.PageCount)
                .Take(4);
        }
        // fetch
        public IEnumerable<Book> BooksThatContainBuildingInDescDescendingOrderTakeLast4() {
            return bookCollection
                .Where(book => book.LongDescription != null && book.LongDescription.Contains("building"))
                .OrderByDescending(book => book.PageCount)
                .TakeLast(4);
        }

        public IEnumerable<Book> BooksThatContainBuildingInDescDescendingOrderTakeTop2Skip4() {
            return bookCollection
                .Where(book => book.LongDescription != null && book.LongDescription.Contains("building"))
                .OrderByDescending(book => book.PageCount)
                .Take(2).Skip(4);
        }

        public IEnumerable<Book> BooksCategoryJavaTop5Skip2() {
            return bookCollection
                .Where(book => book.Categories.Contains("Java"))
                .Take(5).Skip(2);
        }

        public IEnumerable<Book> BooksTitlesNotAvaible(){
            return bookCollection.Where(book => book.PageCount == 0).Select(book => new Book{Title=book.Title});
        }

        public DateTime OldestPublishDate(){
            return bookCollection.Min(book => book.PublishedDate);
        }
        public DateTime NewestPublishDate(){
            return bookCollection.Max(book => book.PublishedDate);
        }
        

        public Book BooksWithPageCountMoreThan450(){
            return bookCollection.Where(book => book.PageCount > 450).MinBy(book => book.PublishedDate);
        }

        public int SumOfBooksPagesWithPageCountMoreThan450(){
            return bookCollection.Where(book => book.PageCount > 450).Sum(book => book.PageCount);
        }

        public int NumberOfBooksMoreThan450(){
            return bookCollection.Count(book => book.PageCount > 450);d
        }

    }





}