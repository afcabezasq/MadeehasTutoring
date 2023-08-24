namespace LINQ
{
    public class Book
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Status { get; set; }
        public DateTime PublishedDate { get; set; }
        public string[] Authors { get; set; }
        public string[] Categories { get; set; }


        public override string ToString()
        {
            //String interpolation
            return $"Title: {Title}, Number Of Pages: {PageCount}, Status: {Status}, Publish Date: {PublishedDate}";
            // f""
            // $``
        }
    }
}