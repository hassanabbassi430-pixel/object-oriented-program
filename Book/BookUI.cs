using LibraryApp.Common;
using System.Reflection;

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
                Console.WriteLine("7. show lowstock");
                Console.WriteLine("8.show range of books");
                Console.WriteLine("9.Filter Code");
                Console.WriteLine("10.EXIST");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter option: ");
                string option = Console.ReadLine();

                if (option == "10")
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
                else if (option == "7")
                {
                    ShowLowStock();
                }
                else if (option == "8")
                {
                    ShowRangeStock();
                }
                else if (option == "9")
                {
                    ShowFilterData();
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
            Console.Write("Enter book category: ");
            string category = Console.ReadLine();

            Console.WriteLine(service.AddBook(name, author, copies, category));
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
            Console.WriteLine("are you sure:");
            List<BookModel> books = service.GetAllBooks();

            if (index < 0 || index >= books.Count)
            {
                Console.WriteLine("Invalid index!");
                return;
            }

            Console.Write("Delete \"" + books[index].GetName() + "\"? (y/n): ");
            string answer = Console.ReadLine();
            if (answer.Trim().ToLower() != "y")
            {
                Console.WriteLine("no book deleted.deletion cancelled");
                return;
            }

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
                                  " | Copies: " + books[i].GetCopies()+
                                  " | category" + books[i].Getcategory());
            }
        }

        private void SearchBook()
        {
            Console.Write("Enter author name : ");
            string author = Console.ReadLine();

            List<BookModel> found = service.SearchBook(author);

            if (found.Count == 0)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            foreach (BookModel book in found)
            {
                Console.WriteLine("Found: " + book.GetName() +
                                  " | Author: " + book.GetAuthor() +
                                  " | Copies: " + book.GetCopies()+
                                  " | category" + book.Getcategory());
            }
        }

        private void ShowFilterData()
        {
            Console.Write("Enter author name : ");
            string author = Console.ReadLine();

            Console.Write("Enter category : ");
            string category = Console.ReadLine();

            int mini = InputHelper.ReadNumber("Enter mini of book: ");
            int max = InputHelper.ReadNumber("Enter max  of book: ");

            List<BookModel> found = service.GetFilterData(author, mini, max, category);

            if (found.Count == 0)
            {
                Console.WriteLine("Book not found!");
                return;
            }


                foreach (BookModel book in found)
                {
                    Console.WriteLine("Found: " + book.GetName() +
                                      " | Author: " + book.GetAuthor() +
                                      " | Copies: " + book.GetCopies() +
                                      " | category" + book.Getcategory());

                    Console.WriteLine(book.GetName() + " | Copies: " + book.GetCopies());
                }
            }
        


            
        


        private void SortBooks()
        {
            service.SortBooks();

            Console.WriteLine("Books sorted successfully!");
            ShowAllBooks();
        }

        private void ShowRangeStock()
        {
            int mini = InputHelper.ReadNumber("Enter mini of book: ");
            int max = InputHelper.ReadNumber("Enter max  of book: ");

            List<BookModel> middle = service.GetStockRangeBooks(mini,max);
            
            if (middle.Count == 0)
            {
                Console.WriteLine("No books found!");
                return;
            }

            Console.WriteLine("\n---  STOCK BOOKS IN RANGE ---");

            foreach (BookModel book in middle)
            {
                Console.WriteLine(book.GetName() + " | Copies: " + book.GetCopies());
            }
        }


        private void ShowLowStock()
        {
            int limit = InputHelper.ReadNumber("Show books with copies up to: ");

            List<BookModel> low = service.GetLowStockBooks(limit);

            if (low.Count == 0)
            {
                Console.WriteLine("No books found!");
                return;
            }

            Console.WriteLine("\n--- LOW STOCK BOOKS ---");

            foreach (BookModel book in low)
            {
                Console.WriteLine(book.GetName() + " | Copies: " + book.GetCopies());
            }
        }
    }
}
