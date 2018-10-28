using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace NET.W._2018.Hoha._08
{
    public class BookListService
    {
        string path = "/Users/alexhoha/Projects/NET.W.2018.Hoha.08/NET.W.2018.Hoha.08/bookStorage.dat";
        public List<Book> BookListStorage = new List<Book>();

        public BookListService(params Book[] b)
        {
            foreach(Book i in b)
            {
                AddBook(i);
            }
        }

        public BookListService(string path)
        {
            LoadFromFile(path);
        }

        public void AddBook(Book b)
        {
            if (b == null)
                throw new ArgumentException();
            foreach(Book i in BookListStorage)
            {
                if (b.Isbn == i.Isbn)
                {
                    throw new ArgumentException("ISBN already exists");
                }
            }
            BookListStorage.Add(b);
        }

        public void RemoveBook(int isbn)
        {
            for (int i = 0; i < BookListStorage.Count; i++)
            {
                if(BookListStorage[i].Isbn == isbn)
                {
                    BookListStorage.RemoveAt(i);
                    i--;
                    return;
                }
            }
            throw new Exception("There is no book with such ISBN");
        }

        public IEnumerable<Book> FindBook(string tag)
        {
            IEnumerable<Book> tempList = from i in BookListStorage
                    where i.Author.ToUpper().Contains(tag.ToUpper()) || i.Publisher.ToUpper().Contains(tag.ToUpper())
                     select i;
            if (tempList.Any())
                return tempList;
            else
                throw new Exception("Nothing found");
        }

        public IEnumerable<Book> FindBook(int tag)
        {
            IEnumerable<Book> tempList = from i in BookListStorage
                                         where i.Isbn == tag || i.Price == tag || i.NumberOfPages == tag
                                         select i;
            if (tempList.Any())
                return tempList;
            else
                throw new Exception("Nothing found");
        }

        public void SortBook()
        {
            BookListStorage.Sort();
        }

        public void Display()
        {
            foreach(Book b in BookListStorage)
            {
                Console.WriteLine(b);
            }
        }

        public void WriteIntoFile(string path)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                {
                    foreach(Book b in BookListStorage)
                    {
                        writer.Write(b.Isbn);
                        writer.Write(b.Author);
                        writer.Write(b.NumberOfPages);
                        writer.Write(b.Price);
                        writer.Write(b.Publisher);
                        writer.Write(b.YearOfPublishing.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void LoadFromFile(string path)
        {
            List<Book> temp = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while(reader.PeekChar() > 1)
                {
                    int isbn = reader.ReadInt32();
                    string author = reader.ReadString();
                    int num = reader.ReadInt32();
                    double price = reader.ReadDouble();
                    string publisher = reader.ReadString();
                    string yearOfPublishing = reader.ReadString();

                    AddBook(new Book(isbn,author,publisher,DateTime.Parse(yearOfPublishing),num,price));
                }
            }
        }
    }
}
