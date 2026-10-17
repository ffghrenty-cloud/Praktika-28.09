using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BibliotekaWPF.Data;
using BibliotekaWPF.Models;

namespace BibliotekaWPF
{
    public partial class MainWindow : Window
    {
        private readonly BookRepository _repository = new BookRepository();
        private List<Book> _allBooks = new List<Book>();

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _repository.InitializeDatabase();
                _repository.AddSampleBooksIfEmpty();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть базу данных.\n" + ex.Message,
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadBooks()
        {
            _allBooks = _repository.GetAllBooks();
            ApplySearch();
        }

        private void ApplySearch()
        {
            string query = (SearchTextBox.Text ?? "").Trim();
            IEnumerable<Book> result = _allBooks;

            if (!string.IsNullOrWhiteSpace(query))
            {
                result = result.Where(b =>
                    b.Title.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    b.Author.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }

            BooksGrid.ItemsSource = result.ToList();
            CountTextBlock.Text = "Книг: " + result.Count() + " / " + _allBooks.Count;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BooksGrid != null && _allBooks != null)
                ApplySearch();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ApplySearch();
        }

        private void ResetSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Clear();
            ApplySearch();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddBookWindow { Owner = this };
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    _repository.AddBook(dialog.CreatedBook);
                    LoadBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось добавить книгу.\n" + ex.Message,
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            Book selected = BooksGrid.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("Сначала выберите книгу в списке.", "Библиотека",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBoxResult answer = MessageBox.Show(
                "Удалить книгу «" + selected.Title + "»?",
                "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    _repository.DeleteBook(selected.Id);
                    LoadBooks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось удалить книгу.\n" + ex.Message,
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RentBook_Click(object sender, RoutedEventArgs e)
        {
            Book selected = BooksGrid.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("Выберите книгу, которую хотите арендовать.", "Библиотека",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show("Операция аренды книги «" + selected.Title +
                "» подтверждена. По условию задания статус и история аренды не сохраняются.",
                "Аренда книги", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ReturnBook_Click(object sender, RoutedEventArgs e)
        {
            Book selected = BooksGrid.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("Выберите книгу, которую хотите вернуть.", "Библиотека",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show("Операция возврата книги «" + selected.Title +
                "» подтверждена. По условию задания статус и история аренды не сохраняются.",
                "Возврат книги", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
