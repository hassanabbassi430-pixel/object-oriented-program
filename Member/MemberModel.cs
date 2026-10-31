namespace LibraryApp.Member
{
    public class MemberModel
    {
        private string name;
        private string phone;

        public MemberModel(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetPhone(string phone)
        {
            this.phone = phone;
        }

        public string GetPhone()
        {
            return this.phone;
        }

        // this is how a member is written in the file
        public override string ToString()
        {
            return $"{name},{phone}";
        }
    }
}
