using LINQ;

LinqQueries collectionQueries = new LinqQueries();



void PrintValues(IEnumerable<Book> booksList)
{
    Console.WriteLine("{0,-70} {1,7} {2,11}\n","Title","N. Pages", "Publish Date");
    foreach(var item in booksList){
        Console.WriteLine("{0,-70} {1,7} {2,11}\n",item.Title,item.PageCount, item.PublishedDate);
        
    }

}


//Print whole collection
// PrintValues(collectionQueries.WholeCollection());

//Print books more than 250 pages
// PrintValues(collectionQueries.BooksMoreThan250Pages("Java"));

// Print if all the books have status
// Console.WriteLine(collectionQueries.AllBooksHasStatus());
//Console.WriteLine(collectionQueries.IsThereAPublishedBookIn2005());
// PrintValues(collectionQueries.BooksCategoryJavaTop5Skip2());
PrintValues(collectionQueries.BooksTitlesNotAvaible());