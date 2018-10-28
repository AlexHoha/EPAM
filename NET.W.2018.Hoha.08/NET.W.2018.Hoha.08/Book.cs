using System;
namespace NET.W._2018.Hoha._08
{
    public class Book : IComparable<Book>, IEquatable<Book>
    {
        int isbn;
        string author;
        string publisher;
        DateTime yearOfPublishing;
        int numberOfPages;
        double price;

        public int Isbn
        {
            get
            {
                return isbn;
            }
            set
            {
                if(value > 0)
                {
                    isbn = value;
                }
                else throw new ArgumentException();
            }

        }

        public string Author
        {
            get { return author; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    author = value;
                else throw new ArgumentException();
            }
        }

        public string Publisher
        {
            get { return publisher; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                    publisher = value;
                else throw new ArgumentException();
            }
        }

        public DateTime YearOfPublishing
        {
            get { return yearOfPublishing; }
            set { if (value.Year > 0) yearOfPublishing = value; else throw new ArgumentException(); }
                
        }

        public int NumberOfPages
        {
            get { return numberOfPages; }
            set { if (value > 0) numberOfPages = value; else throw new ArgumentException(); }
        }

        public double Price
        {
            get { return price; }
            set { if (value > 0) price = value; else throw new ArgumentException(); }
        }

        public Book(int isbn, string author, string publisher, DateTime yearOfPublishing, int numberOfPages, double price)
        {
            Isbn = isbn;
            Author = author;
            Publisher = publisher;
            YearOfPublishing = yearOfPublishing;
            NumberOfPages = numberOfPages;
            Price = price;
        }

        public int CompareTo(Book other)
        {
            if (other != null)
                return this.Isbn.CompareTo(other.Isbn);
            throw new Exception();
        }

        public bool Equals(Book other)
        {
            return other != null &&  Author == other.Author && Publisher == other.Publisher &&
                                YearOfPublishing == other.YearOfPublishing && NumberOfPages == other.NumberOfPages &&
                                Price == other.Price;
            //Isbn == other.Isbn &&
        }

        public override string ToString()
        {
            return $"ISBN: {Isbn} \n Author: {Author} \n Publisher: {Publisher} \n " +
                $"Year of publishing: {YearOfPublishing} \n Number of pages {NumberOfPages} \n Price: {Price}";
        }
    }
}
