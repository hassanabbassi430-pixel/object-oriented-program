using LibraryApp.Book;
using LibraryApp.Issue;
using LibraryApp.Member;

namespace LibraryApp.Common
{
    // This is the driver class. It shows the main menu
    // and sends the user to the right UI class.
    public class Shop
    {
        private BookUI bookUI = new BookUI();
        private MemberUI memberUI = new MemberUI();
        private IssueUI issueUI = new IssueUI();

        public void Start()
        {
            while (true)
            {
                string option = MainMenu();

                if (option == "1")
                {
                    bookUI.BookMenu();
                }
                else if (option == "2")
                {
                    memberUI.MemberMenu();
                }
                else if (option == "3")
                {
                    issueUI.IssueMenu();
                }
                else if (option == "4")
                {
                    break;
                }
            }
        }

        public string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("---------LIBRARY MANAGEMENT SYSTEM-------");
            Console.WriteLine("-----------------------------------------");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Book Management");
            Console.WriteLine("2. Member Management");
            Console.WriteLine("3. Issue Management");
            Console.WriteLine("4. Exit");
            Console.ForegroundColor = ConsoleColor.White;

            // option is taken as a string so the program
            // does not crash if the user types a letter
            Console.Write("Enter option: ");
            string option = Console.ReadLine();

            return option;
        }
    }
}
