namespace LibraryApp.Issue
{
    // This class only works with the file issues.txt
    public class IssueRepo
    {
        private readonly string fileName;

        public IssueRepo()
        {
            fileName = "issues.txt";

            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
        }

        public void SaveInFile(IssueModel issue)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(issue.ToString());
            }
        }

        public List<IssueModel> GetIssuesFromFile()
        {
            List<IssueModel> issues = new List<IssueModel>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        IssueModel issue = new IssueModel(parts[0], parts[1], parts[2]);
                        issues.Add(issue);
                    }
                }
            }

            return issues;
        }
    }
}
