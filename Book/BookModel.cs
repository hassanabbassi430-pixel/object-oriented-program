namespace LibraryApp.Book
{
    public class BookModel
    {
        private string name;
        private string author;
        private int copies;

        public BookModel(string name, string author, int copies)
        {
            this.name = name;
            this.author = author;
            this.copies = copies;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public string GetAuthor()
        {
            return this.author;
        }

        public void SetCopies(int copies)
        {
            // copies can never go below zero
            if (copies >= 0)
            {
                this.copies = copies;
            }
        }

        public int GetCopies()
        {
            return this.copies;
        }

        // this is how a book is written in the file
        public override string ToString()
        {
            return $"{name},{author},{copies}";
        }
    }
}
