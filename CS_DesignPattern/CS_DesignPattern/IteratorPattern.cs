﻿using System;
using System.Collections.Generic;

namespace CS_DesignPattern
{
    internal class IteratorPattern
    {
        public IteratorPattern()
        {
        }

        public void Main()
        {
            BookShelf bookShelf = new BookShelf();
            bookShelf.appendBook(new Book("Around the world in 80 days"));
            bookShelf.appendBook(new Book("Bible"));
            bookShelf.appendBook(new Book("Cinderella"));
            bookShelf.appendBook(new Book("Daddy-Long-Legs"));
            IIterator it = bookShelf.Iterator();
            while (it.HasNext())
            {
                Book book = (Book)it.Next();
                Console.WriteLine(book.Name);
            }
            // 実行結果
            // Around the world in 80 days
            // Bible
            // Cinderella
            // Daddy-Long-Legs

            // 実行が一瞬で終わって確認できないので、キーの入力を待ちます
            Console.ReadLine();
        }
    }

    // 集合体を表すインターフェース
    public interface IAggregate
    {
        IIterator Iterator();
    }

    // 数え上げ、スキャンを表すインターフェース
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    // 本を表すクラス
    public class Book
    {
        public string Name { get; set; }
        public Book(string name)
        {
            Name = name;
        }
    }

    // 本棚を表すクラス
    public class BookShelf : IAggregate
    {
        List<Book> books = new List<Book>();
        int Last { get; set; } = 0;
        public Book GetBookAt(int index)
        {
            return books[index];
        }
        public void appendBook(Book book)
        {
            books.Add(book);
            Last++;
        }
        public int GetLength()
        {
            return Last;
        }
        public IIterator Iterator()
        {
            return new BookShelfIterator(this);
        }
    }

    // 本棚をスキャンするクラス
    public class BookShelfIterator : IIterator
    {
        BookShelf BookShelf { get; set; }
        int Index { get; set; }
        public BookShelfIterator(BookShelf bookShelf)
        {
            BookShelf = bookShelf;
            Index = 0;
        }
        public bool HasNext()
        {
            if (Index < BookShelf.GetLength())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public object Next()
        {
            Book book = BookShelf.GetBookAt(Index);
            Index++;
            return book;
        }
    }
}