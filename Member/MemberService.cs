namespace LibraryApp.Member
{
    // All the rules for members are written here
    public class MemberService
    {
        private MemberRepo repo = new MemberRepo();

        public List<MemberModel> GetAllMembers()
        {
            return repo.GetMembersFromFile();
        }

        public string AddMember(string name, string phone)
        {
            if (name.Trim() == "")
            {
                return "Invalid member name!";
            }

            if (phone.Trim() == "")
            {
                return "Invalid phone number!";
            }

            // comma is used to separate data in the file
            if (name.Contains(",") || phone.Contains(","))
            {
                return "Name and phone cannot have a comma!";
            }

            MemberModel member = new MemberModel(name.Trim(), phone.Trim());
            repo.SaveInFile(member);

            return "Member added successfully!";
        }

        public string UpdateMember(int index, string name, string phone)
        {
            List<MemberModel> members = repo.GetMembersFromFile();

            if (index < 0 || index >= members.Count)
            {
                return "Invalid index!";
            }

            if (name.Trim() == "")
            {
                return "Invalid member name!";
            }

            if (phone.Trim() == "")
            {
                return "Invalid phone number!";
            }

            if (name.Contains(",") || phone.Contains(","))
            {
                return "Name and phone cannot have a comma!";
            }

            members[index].SetName(name.Trim());
            members[index].SetPhone(phone.Trim());
            repo.SaveAllInFile(members);

            return "Member updated successfully!";
        }

        public string DeleteMember(int index)
        {
            List<MemberModel> members = repo.GetMembersFromFile();

            if (index < 0 || index >= members.Count)
            {
                return "Invalid index!";
            }

            members.RemoveAt(index);
            repo.SaveAllInFile(members);

            return "Member deleted successfully!";
        }
    }
}
