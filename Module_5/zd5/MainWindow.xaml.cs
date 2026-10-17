using System.Windows;
using System.Windows.Controls;

namespace zd5
{
    public partial class MainWindow : Window
    {
        private readonly CalculatorLogic _calc = new CalculatorLogic();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateDisplay()
        {
            Display.Text = _calc.DisplayText;
        }

        // Цифры и точка
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _calc.AddDigit(button.Content.ToString());
            UpdateDisplay();
        }

        // Операции +, -, *, /
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _calc.SetOperation(button.Content.ToString());
            UpdateDisplay();
        }

        // =
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            string error = _calc.Calculate();
            if (error != null)
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateDisplay();
        }

        // C
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _calc.Clear();
            UpdateDisplay();
        }
    }
}