using System;
using System.Windows;
using BibliotekaWPF.Models;

namespace BibliotekaWPF
{
    public partial class AddBookWindow : Window
    {
        public Book CreatedBook { get; private set; }

        public AddBookWindow()
        {
            InitializeComponent();
            YearBox.Text = DateTime.Now.Year.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleBox.Text.Trim();
            string author = AuthorBox.Text.Trim();
            string genre = GenreBox.Text.Trim();
            int year;

            if (title.Length == 0 || author.Length == 0 || genre.Length == 0)
            {
                MessageBox.Show("Заполните название, автора и жанр.", "Проверка данных",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(YearBox.Text.Trim(), out year) || year < 0 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Введите корректный год издания.", "Проверка данных",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CreatedBook = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                Year = year
            };

            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
