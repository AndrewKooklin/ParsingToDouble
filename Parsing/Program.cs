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

            // Варианты ввода
            //first char or first char of string is not digit
            //-
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
            //.
            //,
            //0
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
                position = i;
                char c = input[i];

                if (c == '.' || c == ',')
                {
                    separatorFound = true;
                }

                if (!char.IsDigit(c))
                {
                    return Double.NaN;
                }
                else 
                { 



                }
                
                position ++;
            }


            return output;
        }
            
    }
}
