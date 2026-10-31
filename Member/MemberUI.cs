using LibraryApp.Common;

namespace LibraryApp.Member
{
    // This class only shows the menu and takes input.
    // The real work is done by MemberService.
    public class MemberUI
    {
        private MemberService service = new MemberService();

        public void MemberMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("------------MEMBER MANAGEMENT------------");
                Console.WriteLine("-----------------------------------------");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Update Member");
                Console.WriteLine("3. Delete Member");
                Console.WriteLine("4. View All Members");
                Console.WriteLine("5. Back");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Enter option: ");
                string option = Console.ReadLine();

                if (option == "5")
                {
                    break;
                }
                else if (option == "1")
                {
                    AddMember();
                }
                else if (option == "2")
                {
                    UpdateMember();
                }
                else if (option == "3")
                {
                    DeleteMember();
                }
                else if (option == "4")
                {
                    ShowAllMembers();
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
            }
        }

        private void AddMember()
        {
            Console.Write("Enter member name: ");
            string name = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phone = Console.ReadLine();

            Console.WriteLine(service.AddMember(name, phone));
        }

        private void UpdateMember()
        {
            ShowAllMembers();

            int index = InputHelper.ReadNumber("\nEnter member index: ");

            Console.Write("Enter new name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new phone number: ");
            string phone = Console.ReadLine();

            Console.WriteLine(service.UpdateMember(index, name, phone));
        }

        private void DeleteMember()
        {
            ShowAllMembers();

            int index = InputHelper.ReadNumber("\nEnter member index to delete: ");

            Console.WriteLine(service.DeleteMember(index));
        }

        // public because IssueUI also uses it to show the members
        public void ShowAllMembers()
        {
            List<MemberModel> members = service.GetAllMembers();

            if (members.Count == 0)
            {
                Console.WriteLine("No members available!");
                return;
            }

            Console.WriteLine("\n--- MEMBER LIST ---");

            for (int i = 0; i < members.Count; i++)
            {
                Console.WriteLine(i + ". " + members[i].GetName() +
                                  " | Phone: " + members[i].GetPhone());
            }
        }
    }
}
