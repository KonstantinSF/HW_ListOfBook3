using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HW_ListOfBook3
{
    public class Program
    {
        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
            public bool IsRead { get; set; }
            public Book(int id, string name, string author, bool isRead = false)
            {
                Id = id; Name = name; Author = author;
            }
            public override string ToString()
            {
                return $"N Book is {Id}\t Name: {Name}\t Author: {Author}";
            }
        }
        public class BookList
        {
            Book[] BookArr;
            string Name { get; set; }
            //public int SIZE { get; set; }
            public BookList(int SIZE, string name)
            {
                BookArr = new Book[SIZE];
                Name = name;
            }
            public int Length
            {
                get { return BookArr.Length; }
            }
            public Book this[int index]
            {
                get
                {
                    if (index >= 0 && index < BookArr.Length)
                    {
                        return BookArr[index];
                    }
                    throw new IndexOutOfRangeException();
                }
                set
                {
                    BookArr[index] = value;
                }
            }
            public Book this[string searchName]
            {
                get
                {
                    try
                    {

                        for (int i = 0; i < this.Length; i++)
                        {
                            if (this[i].Name == searchName)
                            {
                                return this[i]; break;
                            }
                        }
                        return null;
                    }
                    catch
                    {
                        throw new Exception("Wrong name");
                    }
                }
            }
            public void IsInBookList(string name)
            {
                bool fined = false;
                foreach (var book in BookArr)
                {
                    if (book.Name == name)
                    {
                        WriteLine($"{name} is in booklist: {this.Name}");
                        fined = true;
                        break;
                    }
                }
                if (!fined) WriteLine($"{name} is NOT in booklist: {this.Name}");
            }
            public void ResizeBook(ref BookList BookArr, int newSize)
            {
                BookList buffer = new BookList(newSize, BookArr.Name);
                if (newSize > BookArr.Length)
                {
                    for (int i = 0; i < BookArr.Length; i++)
                    {
                        buffer[i] = BookArr[i];
                    }
                }
                else
                {
                    for (int i = 0; i < newSize; i++)
                    {
                        buffer[i] = BookArr[i];
                    }
                }
                BookArr = buffer;
            }
            public void AddNewBook(ref BookList BookArr, Book NewBook)
            {
                BookArr.ResizeBook(ref BookArr, BookArr.Length + 1);
                BookArr[BookArr.Length - 1] = NewBook;
            }
            public void DeleteBook(ref BookList BookArr, string name)
            {
                for (int i = 0; i < BookArr.Length - 1; i++)
                {
                    if (BookArr[i].Name == name)
                    {
                        for (int j = i; j < BookArr.Length - 1; j++)
                            BookArr[j] = BookArr[j + 1];
                        break;
                    }
                }
                BookArr.ResizeBook(ref BookArr, BookArr.Length - 1);
            }
            public override string ToString()
            {
                string str = null; 
                for (int i =0; i<this.Length; i++)
                {
                     str += this[i].ToString()+"\n";
                }
                return str;
            }
            public static void Main(string[] args)
            {
                BookList booklist = new BookList(4, "My List");

                booklist[0] = new Book(0, "Kolobok", "Narod");
                booklist[1] = new Book(1, "Robinzon Kruzo", "D.Defo");
                booklist[2] = new Book(2, "451 by Farenheit", "Ray Bradberry");
                booklist[3] = new Book(3, "Notre-Dame de Paris", "Victor Gugo");

                Book bookB = new Book(4, "Iron Mask", "Artyur Berned");
                booklist.AddNewBook(ref booklist, bookB);
                WriteLine($"List after add N4 book:\n {booklist}");
                booklist.DeleteBook(ref booklist, "451 by Farenheit");
                WriteLine($"List after delete N2 book:\n {booklist}");
                booklist.IsInBookList("Kolob");
                WriteLine(booklist["Notre-Dame de Paris"]);
            }
        }
    }
}
