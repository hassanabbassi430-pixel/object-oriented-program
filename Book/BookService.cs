using System.ComponentModel;
using System.ComponentModel.Design;

namespace LibraryApp.Book
{
    // All the rules for books are written here
    public class BookService
    {
        private BookRepo repo = new BookRepo();
        private int maxBooks = 20;

        public List<BookModel> GetAllBooks()
        {
            return repo.GetBooksFromFile();
        }

        public string AddBook(string name, string author, int copies,string category)
        {
            List<BookModel> books = repo.GetBooksFromFile();

            if (books.Count >= maxBooks)
            {
                return "Library is full!";
            }

            if (name.Trim() == "")
            {
                return "Invalid book name!";
            }

            if (author.Trim() == "")
            {
                return "Invalid author name!";
            }

            if (category.Trim() == "")
            {
                return "Invalid category!";
            }

            // comma is used to separate data in the file
            if (name.Contains(",") || author.Contains(",") || category.Contains(","))
            {
                return "Name and author and category cannot have a comma!";
            }

            if (copies <= 0)
            {
                return "Copies must be greater than 0!";
            }

            foreach(BookModel b in books)
            {
                if (b.GetName().ToLower() == name.Trim().ToLower())
                {
                    Console.WriteLine("book already exists");
                }
            }

            BookModel book = new BookModel(name.Trim(), author.Trim(), copies, category.Trim());
            repo.SaveInFile(book);

            return "Book added successfully!";
        }

        public string UpdateCopies(int index, int add)
        {
            List<BookModel> books = repo.GetBooksFromFile();

            if (index < 0 || index >= books.Count)
            {
                return "Invalid index!";
            }

            int newCopies = books[index].GetCopies() + add;

            if (newCopies < 0)
            {
                return "Copies cannot be less than 0!";
            }

            books[index].SetCopies(newCopies);
            repo.SaveAllInFile(books);

            return "Copies updated!";
        }

        public List<BookModel> SearchBook(string author)
        {
            List<BookModel> books = repo.GetBooksFromFile();
            List<BookModel> found = new List<BookModel>();

            foreach (BookModel book in books)
            {
                if (book.GetAuthor().ToLower().Contains(author.Trim().ToLower()))
                {
                    found.Add(book);
                }
            }

            return found;
        }

        public List<BookModel> GetLowStockBooks(int limit)
        {
           List<BookModel>books= repo.GetBooksFromFile();
            List<BookModel> Low = new List <BookModel>();
            foreach(BookModel book in books)
            {
                if(book.GetCopies() <= limit)
                {
                    Low.Add(book);
                }
            }
            return Low;

        }

        public List<BookModel> GetStockRangeBooks(int mini,int max)
        {
            List<BookModel> books = repo.GetBooksFromFile();
            List<BookModel> middle= new List<BookModel>();
            foreach (BookModel book in books)
            {
                if (book.GetCopies() >mini && book.GetCopies()<max)
                {
                    middle.Add(book);
                }
            }
            return middle;

        }

        public List<BookModel> GetFilterData(string author,int mini, int max,string category)
        {
            List<BookModel> books = repo.GetBooksFromFile();
            List<BookModel> found = new List<BookModel>();

            foreach (BookModel book in books)
            {
                if (book.GetAuthor().ToLower().Contains(author.Trim().ToLower()) && (book.Getcategory().ToLower().Contains(category.Trim().ToLower())))
                {
                    found.Add(book);
                }
            }

            return found;

            List<BookModel> bookss = repo.GetBooksFromFile();
            List<BookModel> middle = new List<BookModel>();
            foreach (BookModel book in bookss)
            {
                if (book.GetCopies() > mini && book.GetCopies() < max)
                {
                    middle.Add(book);
                }
            }
            return middle;

        }
        public void SortBooks()
        {
            List<BookModel> books = repo.GetBooksFromFile();

            books = books.OrderBy(b => b.GetName()).ToList();

            repo.SaveAllInFile(books);
        }



        public string DeleteBook(int index)
        {
            List<BookModel> books = repo.GetBooksFromFile();

            if (index < 0 || index >= books.Count)
            {
                return "Invalid index!";
            }

                books.RemoveAt(index);
                repo.SaveAllInFile(books);

                return "Book deleted successfully!";
            
            }
        }
    }

