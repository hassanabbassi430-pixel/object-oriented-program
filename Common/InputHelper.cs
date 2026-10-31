namespace LibraryApp.Common
{
    // small helper used by all the UI classes
    public class InputHelper
    {
        // keeps asking until the user types a proper number
        public static int ReadNumber(string message)
        {
            int number;

            Console.Write(message);

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Please enter a number: ");
            }

            return number;
        }
    }
}
