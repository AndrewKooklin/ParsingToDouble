using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingToDouble
{
    class Program
    {
        private static bool isExistE = false;
        private static bool negative = false;
        const double min = -1.7976931348623157E+308;
        const double max = 1.7976931348623157E+308;
        static void Main(string[] args)
        {
            ConsoleKeyInfo btn;
            Console.WriteLine("Программа преобразования строки в тип \"Double\".");
            Console.WriteLine("\nДля выхода из приложения нажмите \"Q\"");

            do
            {
                Console.WriteLine("\nВведите число с плавающей точкой или запятой :");

                isExistE = false;

                string consoleInput = Console.ReadLine();

                double output = StringParsingToDouble(consoleInput);

                if (negative)
                {
                    output *= -1d;
                }
                
                if (Double.IsNaN(output))
                {
                    Console.WriteLine($"Невозможно привести строку \"{consoleInput}\" к типу \"Double\".");
                }
                else if (Double.IsInfinity(output) || output < min || output > max)
                {
                    Console.WriteLine("Число вышло за диапазон типа \"Double\".");
                }
                else if(isExistE)
                {
                    Console.WriteLine($"Строка {consoleInput} может быть приведена" +
                                      $"\nк типу \"Double\" и будет иметь вид : " +
                                      $"{output.ToString("0.###E+000", CultureInfo.InvariantCulture)}");
                }
                else
                {
                    Console.WriteLine($"Строка {consoleInput} может быть приведена" +
                                      $"\nк типу \"Double\" и будет иметь вид : {Math.Round(output, 3)}");
                }

                btn = Console.ReadKey();
            }
            while (btn.Key != ConsoleKey.Q);
        }

        private static double StringParsingToDouble(string input)
        {
            double output = 0d;
            bool negativeExp = false;

            if (input.Length == 1 && input[0] == '-')
            {
                return Double.NaN;
            }
            if(char.IsWhiteSpace(input[0]))
            {
                return Double.NaN;
            }
            if (input.Contains<char>(' '))
            {
                return Double.NaN;
            }
            else if (input.Length > 1 && input[0] == '-')
            {
                negative = true;
            }

            // Варианты ввода
            //first char or first char of string is not digit
            //-
            //.
            //,
            //-.
            //-.123
            //-123
            //-123.
            //-123.
            //-123.123
            //-123e(E)0
            //-123e(E)123
            //-123e(E)+
            //-123e(E)+123
            //0
            //0e
            //0e+
            //0e0
            //0e123
            //123
            //123.123
            //0.
            //0.123
            //0.1e(E)0
            //0.1e(E)123
            //0.1e(E)+
            //0.1e(E)+123

            double exp = 0d;
            double outputMultiply = 0d;
            double multiplyIntPart = 1d;
            decimal fraction = 0m;

            for (int i = (negative ? 1 : 0); i < input.Length; i++)
            {
                int j = 0;
                
                char c = input[i];
                if (Char.IsWhiteSpace(input[i]))
                {
                    return Double.NaN;
                }
                else if (!char.IsDigit(c))
                {
                    if (c == '.' || c == ',')
                    {
                        decimal multiply = 10;
                        for (j = i + 1; j < input.Length; j++)
                        {
                            c = input[j];
                            
                            switch (c)
                            {
                                case '0':
                                default:
                                    {
                                        fraction += 0m;
                                        break;
                                    }
                                case '1':
                                    {
                                        fraction += (1m / multiply);
                                        break;
                                    }
                                case '2':
                                    {
                                        fraction += (2m / multiply);
                                        break;
                                    }
                                case '3':
                                    {
                                        fraction += (3m / multiply);
                                        break;
                                    }
                                case '4':
                                    {
                                        fraction += (4m / multiply);
                                        break;
                                    }
                                case '5':
                                    {
                                        fraction += (5m / multiply);
                                        break;
                                    }
                                case '6':
                                    {
                                        fraction += (6m / multiply);
                                        break;
                                    }
                                case '7':
                                    {
                                        fraction += (7m / multiply);
                                        break;
                                    }
                                case '8':
                                    {
                                        fraction += (8m / multiply);
                                        break;
                                    }
                                case '9':
                                    {
                                        fraction += (9m / multiply);
                                        break;
                                    }
                            }
                            multiply *= 10m;

                            if (c == 'e' || c == 'E')
                            {
                                isExistE = true;

                                if (j < input.Length - 1)
                                {
                                    c = input[++j];
                                }
                                if(c == '-')
                                {
                                    negativeExp = true;
                                }
                                if((c == '+' || c == '-') && j == input.Length - 1)
                                {
                                    return Double.NaN;
                                }
                                if ((c == '+' || c == '-'))
                                {
                                    c = input[++j];
                                    if (!char.IsDigit(c))
                                    {
                                        return Double.NaN;
                                    }
                                }

                                double multiplyExp = 1d;

                                for (int k = j; k < input.Length; k++)
                                {
                                    c = input[k];
                                    if (!char.IsDigit(c) || c == ' ')
                                    {
                                        return Double.NaN;
                                    }
                                    else if (c == '+' || c == '-')
                                    {
                                        k++;
                                        c = input[k];
                                    }

                                    switch (c)
                                    {
                                        case '0':
                                        default:
                                            {
                                                exp *= 10d;
                                                break;
                                            }
                                        case '1':
                                            {
                                                exp = (exp * multiplyExp) + 1d;
                                                break;
                                            }
                                        case '2':
                                            {
                                                exp = (exp * multiplyExp) + 2d;
                                                break;
                                            }
                                        case '3':
                                            {
                                                exp = (exp * multiplyExp) + 3d;
                                                break;
                                            }
                                        case '4':
                                            {
                                                exp = (exp * multiplyExp) + 4d;
                                                break;
                                            }
                                        case '5':
                                            {
                                                exp = (exp * multiplyExp) + 5d;
                                                break;
                                            }
                                        case '6':
                                            {
                                                exp = (exp * multiplyExp) + 6d;
                                                break;
                                            }
                                        case '7':
                                            {
                                                exp = (exp * multiplyExp) + 7d;
                                                break;
                                            }
                                        case '8':
                                            {
                                                exp = (exp * multiplyExp) + 8d;
                                                break;
                                            }
                                        case '9':
                                            {
                                                exp = (exp * multiplyExp) + 9d;
                                                break;
                                            }
                                    }
                                    multiplyExp = 10d;
                                }
                                if (negativeExp)
                                {
                                    exp *= -1d;
                                }
                                
                                output += (Double)fraction;
                                return output *= Math.Pow(10, exp);
                            }
                        }
                         
                        output += (Double)fraction;
                        return output;
                    }
                    else if (c == 'e' || c == 'E')
                    {
                        isExistE = true;

                        if (i < input.Length - 1)
                        {
                            c = input[++i];
                        }

                        if (c == '-')
                        {
                            negativeExp = true;
                        }
                        if ((c == '+' || c == '-') && i == input.Length - 1)
                        {
                            return Double.NaN;
                        }
                        if ((c == '+' || c == '-'))
                        {
                            c = input[++i];
                            if (!char.IsDigit(c))
                            {
                                return Double.NaN;
                            }
                        }
                        

                        double multiplyExp = 1d;

                        for (int k = i; k < input.Length; k++)
                        {
                            c = input[k];
                            if (c == 'e' || c == 'E' || c == ' ')
                            {
                                return Double.NaN;
                            }
                            else if (c == '+' || c == '-')
                            {
                                k++;
                                c = input[k];
                            }

                            switch (c)
                            {
                                case '0':
                                default:
                                    {
                                        exp *= 10d;
                                        break;
                                    }
                                case '1':
                                    {
                                        exp = (exp * multiplyExp) + 1d;
                                        break;
                                    }
                                case '2':
                                    {
                                        exp = (exp * multiplyExp) + 2d;
                                        break;
                                    }
                                case '3':
                                    {
                                        exp = (exp * multiplyExp) + 3d;
                                        break;
                                    }
                                case '4':
                                    {
                                        exp = (exp * multiplyExp) + 4d;
                                        break;
                                    }
                                case '5':
                                    {
                                        exp = (exp * multiplyExp) + 5d;
                                        break;
                                    }
                                case '6':
                                    {
                                        exp = (exp * multiplyExp) + 6d;
                                        break;
                                    }
                                case '7':
                                    {
                                        exp = (exp * multiplyExp) + 7d;
                                        break;
                                    }
                                case '8':
                                    {
                                        exp = (exp * multiplyExp) + 8d;
                                        break;
                                    }
                                case '9':
                                    {
                                        exp = (exp * multiplyExp) + 9d;
                                        break;
                                    }
                            }
                            multiplyExp = 10d;
                        }
                        if (negativeExp)
                        {
                            exp *= -1d;
                        }
                        return output *= Math.Pow(10, exp);
                    }
                    else
                    {
                        return Double.NaN;
                    }
                }
                else
                {
                    switch (c)
                    {
                        case '0':
                        default:
                            {
                                outputMultiply *= 10d;
                                break;
                            }
                        case '1':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 1d;
                                break;
                            }
                        case '2':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 2d;
                                break;
                            }
                        case '3':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 3d;
                                break;
                            }
                        case '4':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 4d;
                                break;
                            }
                        case '5':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 5d;
                                break;
                            }
                        case '6':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 6d;
                                break;
                            }
                        case '7':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 7d;
                                break;
                            }
                        case '8':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 8d;
                                break;
                            }
                        case '9':
                            {
                                outputMultiply = (outputMultiply * multiplyIntPart) + 9d;
                                break;
                            }
                    }

                    multiplyIntPart = 10d;
                    output = outputMultiply;
                }
            }

            return output;
        }
    }
}
