using System;

namespace Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Программа преобразования строки в тип \"Double\"." +
                "\nВведите число с плавающей точкой или запятой :");

                string consoleInput = Console.ReadLine();
                double output = StringParsingToDouble(consoleInput);
                if (Double.IsNaN(output))
                {
                    Console.WriteLine("Невозможно привести строку к типу \"Double\".");
                }
                else
                {
                    Console.WriteLine($"Строка {consoleInput} может быть приведена" +
                                      $"\nк типу \"Double\" и будет иметь вид : {output}");
                }

                Console.WriteLine("Для выхода из приложения нажмите \"Esc\"");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static double StringParsingToDouble(string input)
        {
            double output = 0;
            const double min = -1.7976931348623157E+308;
            const double max = 1.7976931348623157E+308;
            int position = 0;
            bool separatorFound = false;
            bool negative = false;
            if (input[0] == '-')
            {
                negative = true;
            }

            //a
            //-
            //.
            //0
            //0.
            //0.123
            //0.1e0
            //0.1e123
            //123
            //123.123

            for (int i = (negative ? 1 : 0); i < input.Length; i++)  
            {
                char c = input[i];
                if (!char.IsDigit(c))
                {
                    return Double.NaN;
                }
                
                if (c == '.' || c == ',')
                {
                    separatorFound = true;
                }
                else
                {
                    if (position > 0 && !char.IsDigit(c))
                    {
                        output += c;
                    }
                    else
                    {
                        return Double.NaN;
                    }
                }
                position ++;
            }


            return output;
        }
            
    }
}
