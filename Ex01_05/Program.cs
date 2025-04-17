using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            const int k_InputLength = 8;

            Console.WriteLine("Please enter a 8 digits number: ");
            string input = Console.ReadLine();
            int inputAsNumber;

            while (isValidInput(input, k_InputLength) != true || int.TryParse(input, out inputAsNumber) != true)
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine("Please enter a 8 digits number: ");
                input = Console.ReadLine();
            }

            howManyDigitsSmallerThanTheFirstDigit(input);
            howManyDividableBy3(input);
            maxAndMinDigitsDifference(input);
            mostFrequentDigit(input);

            Console.ReadLine();
        }

        private static bool isValidInput(string i_input, int i_validLength)
        {
            bool isValid = true;

            if (i_input[0] == '-')
            {
                isValid = false;
            }

            if (string.IsNullOrEmpty(i_input) || i_input.Length != i_validLength)
            {
                isValid = false;
            }

            return isValid;
        }

        private static void howManyDigitsSmallerThanTheFirstDigit(string i_inputAsString)
        {
            int amountOfNumbersSmallerThanTheFirstDigit = 0;

            for(int i = 1; i < i_inputAsString.Length; i++)
            {
                if (i_inputAsString[i] < i_inputAsString[0])
                {
                    amountOfNumbersSmallerThanTheFirstDigit++;
                }
            }

            Console.WriteLine(string.Format("The left Digit is: {0}. Digits smallers than it (exluding the first): {1}"
                ,i_inputAsString[0], amountOfNumbersSmallerThanTheFirstDigit));
        }

        private static void howManyDividableBy3(string i_inputAsString)
        {
            int amountOfNumbersDividableBy3 = 0;

            foreach(char digit in i_inputAsString)
            {
               if((digit - '0') % 3 == 0)
               {
                   amountOfNumbersDividableBy3++;
               }
            }

            Console.WriteLine(string.Format("Digits dividable By 3: {0}", amountOfNumbersDividableBy3));
        }

        private static void maxAndMinDigitsDifference(string i_inputAsString)
        {
            int min = i_inputAsString[0] - '0';
            int max = min;

            int currentDigit;

            foreach(char digit in i_inputAsString)
            {
                currentDigit = digit - '0';

                if (currentDigit < min)
                {
                    min = currentDigit;
                }
                if(currentDigit > max)
                {
                    max = currentDigit;
                }
            }

            Console.WriteLine(string.Format("Difference: {0}", max - min));
        }

        private static void mostFrequentDigit(string i_inputAsString)
        {
            int mostFrequentDigit = i_inputAsString[0] - '0';
            int maxAppearance = 0;

            for(char digit = '0'; digit <= '9'; digit++)
            {
                int count = 0;

                foreach(char charachter in i_inputAsString)
                {
                    if(charachter == digit)
                    {
                        count++;
                    }
                }

                if(count > maxAppearance)
                {
                    mostFrequentDigit = digit - '0';
                    maxAppearance = count;
                }
            }

            Console.WriteLine(string.Format("Most frequent digit: {0} (shows {1} times)", mostFrequentDigit, maxAppearance));
        }
    }
}
