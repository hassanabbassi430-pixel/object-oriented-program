using LibraryApp.Common;

namespace LibraryApp.Book
{
    // This class only shows the menu and takes input.
    // The real work is done by BookService.
    public class BookUI
    {
        private BookService service = new BookService();

        public void BookMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("-------------BOOK MANAGEMENT-------------");
                Console.WriteLine("-----------------------------------------");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Copies");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Search Book");
                Console.WriteLine("6. Sort Books");
                Console.WriteLine("7. Back");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter option: ");
                string option = Console.ReadLine();

                if (option == "7")
                {
                    break;
                }
                else if (option == "1")
                {
                    AddBook();
                }
                else if (option == "2")
                {
                    UpdateCopies();
                }
                else if (option == "3")
                {
                    DeleteBook();
                }
                else if (option == "4")
                {
                    ShowAllBooks();
                }
                else if (option == "5")
                {
                    SearchBook();
                }
                else if (option == "6")
                {
                    SortBooks();
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }
        }

        private void AddBook()
        {
            Console.Write("Enter book name: ");
            string name = Console.ReadLine();

            Console.Write("Enter author name: ");
            string author = Console.ReadLine();

            int copies = InputHelper.ReadNumber("Enter number of copies: ");

            Console.WriteLine(service.AddBook(name, author, copies));
        }

        private void UpdateCopies()
        {
            ShowAllBooks();

            int index = InputHelper.ReadNumber("\nEnter book index: ");
            int add = InputHelper.ReadNumber("Enter copies to add: ");

            Console.WriteLine(service.UpdateCopies(index, add));
        }

        private void DeleteBook()
        {
            ShowAllBooks();

            int index = InputHelper.ReadNumber("\nEnter book index to delete: ");

            Console.WriteLine(service.DeleteBook(index));
        }

        // public because IssueUI also uses it to show the books
        public void ShowAllBooks()
        {
            List<BookModel> books = service.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books available!");
                return;
            }

            Console.WriteLine("\n--- BOOK LIST ---");

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine(i + ". " + books[i].GetName() +
                                  " | Author: " + books[i].GetAuthor() +
                                  " | Copies: " + books[i].GetCopies());
            }
        }

        private void SearchBook()
        {
            Console.Write("Enter book name: ");
            string name = Console.ReadLine();

            List<BookModel> found = service.SearchBook(name);

            if (found.Count == 0)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            foreach (BookModel book in found)
            {
                Console.WriteLine("Found: " + book.GetName() +
                                  " | Author: " + book.GetAuthor() +
                                  " | Copies: " + book.GetCopies());
            }
        }

        private void SortBooks()
        {
            service.SortBooks();

            Console.WriteLine("Books sorted successfully!");
            ShowAllBooks();
        }
    }
}
