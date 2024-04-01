using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            const double min = -1.7976931348623157E+308;
            const double max = 1.7976931348623157E+308;
            do
            {
                Console.WriteLine("Программа преобразования строки в тип \"Double\"." +
                "\nВведите число с плавающей точкой или запятой :");

                string consoleInput = Console.ReadLine();
                
                double output = StringParsingToDouble(consoleInput);
                if (Double.IsNaN(output))
                {
                    Console.WriteLine("Невозможно привести строку к типу \"Double\".");
                    break;
                }
                else if(output > max || output < min)
                {
                    Console.WriteLine("Число вышло за диапазон типа \"Double\".");
                    break;
                }
                else
                {
                    Console.WriteLine($"Строка {consoleInput} может быть приведена" +
                                      $"\nк типу \"Double\" и будет иметь вид : {output}");
                }

                Console.WriteLine("Для выхода из приложения нажмите \"Esc\"");
                Console.ReadKey();
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static double StringParsingToDouble(string input)
        {
            double output = 0;
            //int position = 0;
            //bool separatorFound = false;
            //int separatorIndex = 0;
            bool negative = false;
            //bool exp = false;

            if(input.Length == 1 && input[0] == '-')
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

            for (int i = (negative ? 1 : 0); i < input.Length; i++)
            {
                int j = 0;
                //position = i;
                char c = input[i];
                if (Char.IsWhiteSpace(input[i]))
                {
                    return Double.NaN;
                }
                else if (!char.IsDigit(c))
                {
                    if (c == '.' || c == ',')
                    {
                        //separatorFound = true;
                        //separatorIndex = i;
                        for (j = i + 1; j < input.Length; j++)
                        {
                            c = input[j];
                            int multiply = 10;
                            switch (c)
                            {
                                case '0':
                                default:
                                    {
                                        output += 0;
                                        break;
                                    }
                                case '1':
                                    {
                                        output += 1 / multiply;
                                        break;
                                    }
                                case '2':
                                    {
                                        output += 2 / multiply;
                                        break;
                                    }
                                case '3':
                                    {
                                        output += 3 / multiply;
                                        break;
                                    }
                                case '4':
                                    {
                                        output += 4 / multiply;
                                        break;
                                    }
                                case '5':
                                    {
                                        output += 5 / multiply;
                                        break;
                                    }
                                case '6':
                                    {
                                        output += 6 / multiply;
                                        break;
                                    }
                                case '7':
                                    {
                                        output += 7 / multiply;
                                        break;
                                    }
                                case '8':
                                    {
                                        output += 8 / multiply;
                                        break;
                                    }
                                case '9':
                                    {
                                        output += 9 / multiply;
                                        break;
                                    }
                            }
                            multiply *= 10;
                        }
                    }
                    else if (c == 'e' || c == 'E')
                    {
                        double outputMultiply = 0;
                        //exp = true;
                        
                        for (int k = i+1; k < input.Length; k++)
                        {
                            c = input[k];
                            if (c == '0')
                            {
                                return output;
                            }
                            
                            double multiply = 1;
                            switch (c)
                            {
                                default:
                                    {
                                        output *= 1;
                                        return output;
                                    }
                                case '1':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 1;
                                        break;
                                    }
                                case '2':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 2;
                                        break;
                                    }
                                case '3':
                                    {
                                        output = (outputMultiply * multiply) + 3;
                                        break;
                                    }
                                case '4':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 4;
                                        break;
                                    }
                                case '5':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 5;
                                        break;
                                    }
                                case '6':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 6;
                                        break;
                                    }
                                case '7':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 7;
                                        break;
                                    }
                                case '8':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 8;
                                        break;
                                    }
                                case '9':
                                    {
                                        outputMultiply = (outputMultiply * multiply) + 9;
                                        break;
                                    }
                            }
                            multiply *= 10;
                        }
                        output *= Math.Pow(10, outputMultiply);
                    }
                    else
                    {
                        return Double.NaN;
                    }
                }
                else
                {
                    double outputMultiply = 0;
                    double multiply = 1;
                    switch (c)
                    {
                        case '0':
                        default:
                            {
                                outputMultiply = 0;
                                break;
                            }
                        case '1':
                            {
                                outputMultiply = (outputMultiply * multiply) + 1;
                                break;
                            }
                        case '2':
                            {
                                outputMultiply = (outputMultiply * multiply) + 2;
                                break;
                            }
                        case '3':
                            {
                                outputMultiply = (outputMultiply * multiply) + 3;
                                break;
                            }
                        case '4':
                            {
                                outputMultiply = (outputMultiply * multiply) + 4;
                                break;
                            }
                        case '5':
                            {
                                outputMultiply = (outputMultiply * multiply) + 5;
                                break;
                            }
                        case '6':
                            {
                                outputMultiply = (outputMultiply * multiply) + 6;
                                break;
                            }
                        case '7':
                            {
                                outputMultiply = (outputMultiply * multiply) + 7;
                                break;
                            }
                        case '8':
                            {
                                outputMultiply = (outputMultiply * multiply) + 8;
                                break;
                            }
                        case '9':
                            {
                                outputMultiply = (outputMultiply * multiply) + 9;
                                break;
                            }
                    }
                    multiply *= 10;
                    output = outputMultiply;
                }

                if (negative)
                {
                    output *= -1;
                }

            }

            return output;
        }
    }
}
