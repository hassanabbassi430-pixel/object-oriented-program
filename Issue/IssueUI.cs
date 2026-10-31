using LibraryApp.Book;
using LibraryApp.Common;
using LibraryApp.Member;

namespace LibraryApp.Issue
{
    public class IssueUI
    {
        private IssueService service = new IssueService();
        private BookUI bookUI = new BookUI();
        private MemberUI memberUI = new MemberUI();

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
            memberUI.ShowAllMembers();
            int memberIndex = InputHelper.ReadNumber("\nEnter member index: ");

            bookUI.ShowAllBooks();
            int bookIndex = InputHelper.ReadNumber("\nEnter book index: ");

            Console.WriteLine(service.IssueBook(memberIndex, bookIndex));
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
                Console.WriteLine((i + 1) + ". Member: " + issues[i].GetMemberName() +
                                  " | Book: " + issues[i].GetBookName() +
                                  " | Date: " + issues[i].GetIssueDate());
            }
        }
    }
}
