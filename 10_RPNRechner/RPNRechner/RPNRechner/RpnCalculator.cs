using RPNRechner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace RpnCalculator
{
    public class RpnCalculator
    {
        private const string PLUS = "+";
        private const string MINUS = "-";
        private const string MUL = "*";
        private const string DIV = "/";

        private const char POINT = '.';

        public static bool IsValidNumber(string number)
        {
            bool isValid = false;

            if (!(number[0] == POINT || number[number.Length-1] == POINT))
            {
                isValid = ContainsOnlyNumbers(number) && ArePointsValid(number);
            }

            return isValid;
        }

        private static bool ContainsOnlyNumbers(string number)
        {
            bool isValid = true;

            for (int i = 0; i < number.Length && isValid; i++)
            {
                if (!('0' <= number[i] && number[i] <= '9' || number[i] == POINT))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private static bool ArePointsValid(string number)
        {
            bool isValid = true;
            int counter = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == POINT)
                {
                    counter++;
                }
            }

            isValid = counter <= 1;

            return isValid;
        }

        public static bool IsValidOperator(string operatore)
        {
            return operatore == PLUS || operatore == MINUS || operatore == MUL || operatore == DIV;
        }

        public static double EvaluateExpression(string number)
        {
            string[] numbers = number.Split(' ');
            NumberStack stack = new NumberStack();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsValidNumber(numbers[i]))
                {
                    stack.Push(double.Parse(numbers[i]));
                }
                else if (IsValidOperator(numbers[i]))
                {
                    double firstOperand = stack.Pop();
                    double secondOperand = stack.Pop();
                    double result = PerformOperation(firstOperand, secondOperand, numbers[i]);
                    stack.Push(result);
                }
                else
                {
                    throw new ArgumentException("Expression must contain only numbers and valid operators!");
                }
            }

            return stack.Pop();
        }

        public static double PerformOperation(double firstOperand, double secondOperand, string op)
        {
            double result = 0.0;

            switch (op)
            {
                case PLUS:
                    result = firstOperand + secondOperand;
                    break;

                case MINUS:
                    result = firstOperand - secondOperand;
                    break;

                case MUL:
                    result = firstOperand * secondOperand;
                    break;

                default:
                    if(secondOperand != 0)
                    {
                        result = firstOperand / secondOperand;
                    }

                    break;
            }

            return result;
        }
    }
}
