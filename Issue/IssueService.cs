using LibraryApp.Book;
using LibraryApp.Member;

namespace LibraryApp.Issue
{
    // Rules for borrowing and returning books.
    // It uses BookService to change the number of copies
    // and MemberService to check the member.
    public class IssueService
    {
        private IssueRepo repo = new IssueRepo();
        private BookService bookService = new BookService();
        private MemberService memberService = new MemberService();

        public string IssueBook(int memberIndex, int bookIndex)
        {
            List<MemberModel> members = memberService.GetAllMembers();
            List<BookModel> books = bookService.GetAllBooks();

            if (members.Count == 0)
            {
                return "No members available! Add a member first.";
            }

            if (books.Count == 0)
            {
                return "No books available!";
            }

            if (memberIndex < 0 || memberIndex >= members.Count)
            {
                return "Invalid member index!";
            }

            if (bookIndex < 0 || bookIndex >= books.Count)
            {
                return "Invalid book index!";
            }

            if (books[bookIndex].GetCopies() == 0)
            {
                return "Book not available!";
            }

            // one copy less in the library
            bookService.UpdateCopies(bookIndex, -1);

            string date = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            IssueModel issue = new IssueModel(members[memberIndex].GetName(),
                                              books[bookIndex].GetName(),
                                              date);
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
