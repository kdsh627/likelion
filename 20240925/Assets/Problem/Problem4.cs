using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book
{
    public string author;
    public string name;

    public Book(string author, string name)
    { 
        this.author = author;
        this.name = name;
    }
}

public class Librarian
{
    struct BookInfo
    {
        public Book book;
        public bool isRent;

        public BookInfo(Book book, bool isRent)
        {
            this.book = book;
            this.isRent = isRent;
        }
    }

    private List<BookInfo> books;

    public Librarian()
    {
        books = new List<BookInfo> ();
    }

    public void AddBook(Book book)
    {
        books.Add(new BookInfo(book, false));
    }

    public void FindBook(string author)
    {
        foreach(BookInfo bookInfo in books)
        {
            if(!bookInfo.isRent)//�� ��������
            {
                Book book = bookInfo.book;
                if(book.author == author)
                {
                    Debug.Log("���� : " + book.author + " ���� : " + book.name);
                }
            }
        }
    }
}


public class Problem4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Librarian librarian = new Librarian();
        librarian.AddBook(new Book("��", "������ʹ�"));
        librarian.AddBook(new Book("��", "������ȴ�"));
        librarian.AddBook(new Book("��", "��������"));

        librarian.FindBook("��");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
