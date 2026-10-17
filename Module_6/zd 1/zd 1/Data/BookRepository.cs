using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using BibliotekaWPF.Models;

namespace BibliotekaWPF.Data
{
    public class BookRepository
    {
        private readonly string _databasePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "library.db");

        private string ConnectionString
        {
            get { return "Data Source=" + _databasePath + ";Version=3;"; }
        }

        public void InitializeDatabase()
        {
            if (!File.Exists(_databasePath))
                SQLiteConnection.CreateFile(_databasePath);

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(@"
                    CREATE TABLE IF NOT EXISTS Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Genre TEXT NOT NULL,
                        Year INTEGER NOT NULL
                    );", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "SELECT Id, Title, Author, Genre, Year FROM Books ORDER BY Title;", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = Convert.ToString(reader["Title"]),
                            Author = Convert.ToString(reader["Author"]),
                            Genre = Convert.ToString(reader["Genre"]),
                            Year = Convert.ToInt32(reader["Year"])
                        });
                    }
                }
            }

            return books;
        }

        public void AddBook(Book book)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "INSERT INTO Books (Title, Author, Genre, Year) VALUES (@title, @author, @genre, @year);",
                    connection))
                {
                    command.Parameters.AddWithValue("@title", book.Title);
                    command.Parameters.AddWithValue("@author", book.Author);
                    command.Parameters.AddWithValue("@genre", book.Genre);
                    command.Parameters.AddWithValue("@year", book.Year);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(
                    "DELETE FROM Books WHERE Id = @id;", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddSampleBooksIfEmpty()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var countCommand = new SQLiteCommand("SELECT COUNT(*) FROM Books;", connection))
                {
                    if (Convert.ToInt32(countCommand.ExecuteScalar()) > 0)
                        return;
                }

                using (var transaction = connection.BeginTransaction())
                using (var command = new SQLiteCommand(
                    "INSERT INTO Books (Title, Author, Genre, Year) VALUES (@title, @author, @genre, @year);",
                    connection, transaction))
                {
                    AddSample(command, "Мастер и Маргарита", "Михаил Булгаков", "Роман", 1967);
                    AddSample(command, "Преступление и наказание", "Фёдор Достоевский", "Роман", 1866);
                    AddSample(command, "1984", "Джордж Оруэлл", "Антиутопия", 1949);
                    AddSample(command, "Война и мир", "Лев Толстой", "Роман", 1869);
                    transaction.Commit();
                }
            }
        }

        private static void AddSample(SQLiteCommand command, string title, string author, string genre, int year)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@author", author);
            command.Parameters.AddWithValue("@genre", genre);
            command.Parameters.AddWithValue("@year", year);
            command.ExecuteNonQuery();
        }
    }
}
