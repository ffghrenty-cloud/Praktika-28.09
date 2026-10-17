using System;

namespace zd5
{
    /// Логика калькулятора, не зависящая от UI.
    public class CalculatorLogic
    {
        private string input = string.Empty;       // Текущий ввод (число)
        private string operation = string.Empty;   // Текущая операция
        private double firstNumber = 0;            // Первое число
        private bool isNewOperation = false;       // Флаг: следующая цифра начинает новое число

        /// Текст, который нужно отобразить на экране.
        public string DisplayText { get; private set; } = string.Empty;

        /// Добавить цифру (или точку) к текущему вводу.
        public void AddDigit(string value)
        {
            if (isNewOperation)
            {
                input = string.Empty;
                DisplayText = string.Empty;
                isNewOperation = false;
            }

            input += value;
            DisplayText += value;
        }

        /// Выбрать операцию (+, -, *, /).
        public void SetOperation(string op)
        {
            if (double.TryParse(input, out firstNumber))
            {
                operation = op;
                DisplayText += $" {operation} ";
                input = string.Empty;
            }
        }

        /// Вычислить результат. Возвращает текст ошибки или null
        public string Calculate()
        {
            if (!double.TryParse(input, out double secondNumber))
                return null;

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                        return "Деление на ноль невозможно";
                    result = firstNumber / secondNumber;
                    break;
                default:
                    return null;
            }

            DisplayText = result.ToString();
            firstNumber = result;
            input = result.ToString();
            isNewOperation = true;

            return null;
        }

        /// Сбросить состояние калькулятора.
        public void Clear()
        {
            input = string.Empty;
            firstNumber = 0;
            operation = string.Empty;
            isNewOperation = false;
            DisplayText = string.Empty;
        }
    }
}