namespace LibraryApp.Book
{
    // All the rules for books are written here
    public class BookService
    {
        private BookRepo repo = new BookRepo();
        private int maxBooks = 20;

        public List<BookModel> GetAllBooks()
        {
            return repo.GetBooksFromFile();
        }

        public string AddBook(string name, string author, int copies)
        {
            List<BookModel> books = repo.GetBooksFromFile();

            if (books.Count >= maxBooks)
            {
                return "Library is full!";
            }

            if (name.Trim() == "")
            {
                return "Invalid book name!";
            }

            if (author.Trim() == "")
            {
                return "Invalid author name!";
            }

            // comma is used to separate data in the file
            if (name.Contains(",") || author.Contains(","))
            {
                return "Name and author cannot have a comma!";
            }

            if (copies <= 0)
            {
                return "Copies must be greater than 0!";
            }

            BookModel book = new BookModel(name.Trim(), author.Trim(), copies);
            repo.SaveInFile(book);

            return "Book added successfully!";
        }

        public string UpdateCopies(int index, int add)
        {
            List<BookModel> books = repo.GetBooksFromFile();

            if (index < 0 || index >= books.Count)
            {
                return "Invalid index!";
            }

            int newCopies = books[index].GetCopies() + add;

            if (newCopies < 0)
            {
                return "Copies cannot be less than 0!";
            }

            books[index].SetCopies(newCopies);
            repo.SaveAllInFile(books);

            return "Copies updated!";
        }

        public List<BookModel> SearchBook(string name)
        {
            List<BookModel> books = repo.GetBooksFromFile();
            List<BookModel> found = new List<BookModel>();

            foreach (BookModel book in books)
            {
                if (book.GetName().ToLower().Contains(name.Trim().ToLower()))
                {
                    found.Add(book);
                }
            }

            return found;
        }

        public void SortBooks()
        {
            List<BookModel> books = repo.GetBooksFromFile();

            books = books.OrderBy(b => b.GetName()).ToList();

            repo.SaveAllInFile(books);
        }

        public string DeleteBook(int index)
        {
            List<BookModel> books = repo.GetBooksFromFile();

            if (index < 0 || index >= books.Count)
            {
                return "Invalid index!";
            }

            books.RemoveAt(index);
            repo.SaveAllInFile(books);

            return "Book deleted successfully!";
        }
    }
}
