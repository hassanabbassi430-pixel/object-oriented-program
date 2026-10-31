namespace LibraryApp.Issue
{
    public class IssueModel
    {
        private string memberName;
        private string bookName;
        private string issueDate;

        public IssueModel(string memberName, string bookName, string issueDate)
        {
            this.memberName = memberName;
            this.bookName = bookName;
            this.issueDate = issueDate;
        }

        public void SetMemberName(string memberName)
        {
            this.memberName = memberName;
        }

        public string GetMemberName()
        {
            return this.memberName;
        }

        public void SetBookName(string bookName)
        {
            this.bookName = bookName;
        }

        public string GetBookName()
        {
            return this.bookName;
        }

        public void SetIssueDate(string issueDate)
        {
            this.issueDate = issueDate;
        }

        public string GetIssueDate()
        {
            return this.issueDate;
        }

        // this is how an issue record is written in the file
        public override string ToString()
        {
            return $"{memberName},{bookName},{issueDate}";
        }
    }
}
