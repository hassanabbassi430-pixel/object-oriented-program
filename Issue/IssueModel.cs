namespace LibraryApp.Issue
{
    public class IssueModel
    {
        private string bookName;
        private string issueDate;

        public IssueModel(string bookName, string issueDate)
        {
            this.bookName = bookName;
            this.issueDate = issueDate;
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
            return $"{bookName},{issueDate}";
        }
    }
}
