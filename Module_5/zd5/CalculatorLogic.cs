using System;

namespace zd5
{
    /// <summary>
    /// Логика калькулятора, не зависящая от UI.
    /// </summary>
    public class CalculatorLogic
    {
        private string input = string.Empty;       // Текущий ввод (число)
        private string operation = string.Empty;   // Текущая операция
        private double firstNumber = 0;            // Первое число
        private bool isNewOperation = false;       // Флаг: следующая цифра начинает новое число

        /// <summary>
        /// Текст, который нужно отобразить на экране.
        /// </summary>
        public string DisplayText { get; private set; } = string.Empty;

        /// <summary>
        /// Добавить цифру (или точку) к текущему вводу.
        /// </summary>
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

        /// <summary>
        /// Выбрать операцию (+, -, *, /).
        /// </summary>
        public void SetOperation(string op)
        {
            if (double.TryParse(input, out firstNumber))
            {
                operation = op;
                DisplayText += $" {operation} ";
                input = string.Empty;
            }
        }

        /// <summary>
        /// Вычислить результат. Возвращает текст ошибки или null, если всё ок.
        /// </summary>
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

        /// <summary>
        /// Сбросить состояние калькулятора.
        /// </summary>
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