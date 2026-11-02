namespace LibraryApp.Book
{
    public class BookModel
    {
        private string name;
        private string author;
        private int copies;
        private string category;

        public BookModel(string name, string author, int copies,string category)
        {
            this.name = name;
            this.author = author;
            this.copies = copies;
            this.category = category;
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

        public void SetCopies(string category)
        {
            this.category=category;

        }
        public string Getcategory()
        {
            return this.category;
        }

        // this is how a book is written in the file
        public override string ToString()
        {
            return $"{name},{author},{copies},{category}";
        }
    }
}
