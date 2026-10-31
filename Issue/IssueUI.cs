using LibraryApp.Book;
using LibraryApp.Common;

namespace LibraryApp.Issue
{
    public class IssueUI
    {
        private IssueService service = new IssueService();
        private BookUI bookUI = new BookUI();

        public void IssueMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("-------------ISSUE MANAGEMENT------------");
                Console.WriteLine("-----------------------------------------");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Borrow Book");
                Console.WriteLine("2. Return Book");
                Console.WriteLine("3. View Issue History");
                Console.WriteLine("4. Back");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter option: ");
                string option = Console.ReadLine();

                if (option == "4")
                {
                    break;
                }
                else if (option == "1")
                {
                    BorrowBook();
                }
                else if (option == "2")
                {
                    ReturnBook();
                }
                else if (option == "3")
                {
                    ShowIssueHistory();
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }
        }

        private void BorrowBook()
        {
            bookUI.ShowAllBooks();

            int index = InputHelper.ReadNumber("\nEnter book index: ");

            Console.WriteLine(service.IssueBook(index));
        }

        private void ReturnBook()
        {
            bookUI.ShowAllBooks();

            int index = InputHelper.ReadNumber("\nEnter book index: ");

            Console.WriteLine(service.ReturnBook(index));
        }

        private void ShowIssueHistory()
        {
            List<IssueModel> issues = service.GetAllIssues();

            if (issues.Count == 0)
            {
                Console.WriteLine("No books issued yet!");
                return;
            }

            Console.WriteLine("\n--- ISSUE HISTORY ---");

            for (int i = 0; i < issues.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + issues[i].GetBookName() +
                                  " | Date: " + issues[i].GetIssueDate());
            }
        }
    }
}
