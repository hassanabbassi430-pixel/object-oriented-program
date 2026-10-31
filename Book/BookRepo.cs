namespace LibraryApp.Book
{
    // This class only works with the file books.txt
    public class BookRepo
    {
        private readonly string fileName;

        public BookRepo()
        {
            fileName = "books.txt";

            // if the file is not there, make it
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }

        // adds one book at the end of the file
        public void SaveInFile(BookModel book)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(book.ToString());
            }
        }

        // writes the whole list again (used after update, delete and sort)
        public void SaveAllInFile(List<BookModel> books)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (BookModel book in books)
                {
                    writer.WriteLine(book.ToString());
                }
            }
        }

        // reads all the books from the file and gives them back as a list
        public List<BookModel> GetBooksFromFile()
        {
            List<BookModel> books = new List<BookModel>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        string name = parts[0];
                        string author = parts[1];
                        int copies = int.Parse(parts[2]);

                        BookModel book = new BookModel(name, author, copies);
                        books.Add(book);
                    }
                }
            }

            return books;
        }
    }
}
