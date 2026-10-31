using LibraryApp.Book;

namespace LibraryApp.Issue
{
    // Rules for borrowing and returning books.
    // It uses BookService to change the number of copies.
    public class IssueService
    {
        private IssueRepo repo = new IssueRepo();
        private BookService bookService = new BookService();

        public string IssueBook(int index)
        {
            List<BookModel> books = bookService.GetAllBooks();

            if (books.Count == 0)
            {
                return "No books available!";
            }

            if (index < 0 || index >= books.Count)
            {
                return "Invalid index!";
            }

            if (books[index].GetCopies() == 0)
            {
                return "Book not available!";
            }

            // one copy less in the library
            bookService.UpdateCopies(index, -1);

            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            IssueModel issue = new IssueModel(books[index].GetName(), date);
            repo.SaveInFile(issue);

            return "Book issued successfully!";
        }

        public string ReturnBook(int index)
        {
            List<BookModel> books = bookService.GetAllBooks();

            if (index < 0 || index >= books.Count)
            {
                return "Invalid index!";
            }

            // one copy back in the library
            bookService.UpdateCopies(index, 1);

            return "Book returned successfully!";
        }

        public List<IssueModel> GetAllIssues()
        {
            return repo.GetIssuesFromFile();
        }
    }
}
