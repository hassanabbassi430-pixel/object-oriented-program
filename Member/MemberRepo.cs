namespace LibraryApp.Member
{
    // This class only works with the file members.txt
    public class MemberRepo
    {
        private readonly string fileName;

        public MemberRepo()
        {
            fileName = "members.txt";

            // if the file is not there, make it
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }

        // adds one member at the end of the file
        public void SaveInFile(MemberModel member)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(member.ToString());
            }
        }

        // writes the whole list again (used after update and delete)
        public void SaveAllInFile(List<MemberModel> members)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (MemberModel member in members)
                {
                    writer.WriteLine(member.ToString());
                }
            }
        }

        // reads all the members from the file and gives them back as a list
        public List<MemberModel> GetMembersFromFile()
        {
            List<MemberModel> members = new List<MemberModel>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        MemberModel member = new MemberModel(parts[0], parts[1]);
                        members.Add(member);
                    }
                }
            }

            return members;
        }
    }
}
