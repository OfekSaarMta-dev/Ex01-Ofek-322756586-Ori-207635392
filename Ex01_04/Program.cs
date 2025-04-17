using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a string that is exactly 12 characters long: ");
            string input = Console.ReadLine();

            while (isValidInput(input) != true)
            {
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine("Enter a 12-character string: ");
                input = Console.ReadLine();
            }

            checkIfPalindrome(input);

            long o_inputAsNumber;
            bool isANumber = long.TryParse(input, out o_inputAsNumber);

            if(isANumber == true)
            {
                countDividableBy3(o_inputAsNumber);
            }

            if(hasOnlyEnglishLetters(input) == true)
            {
                countUppercaseLetters(input);
                isAscendingAlphabetically(input);
            }

            Console.ReadLine();
        }

        private static bool isValidInput(string i_input)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(i_input) || i_input.Length != 12)
            {
                isValid = false;
            }

            return isValid;
        }

        private static void checkIfPalindrome(string i_input)
        {
            bool isPalindrome = isPalindromeRecursive(i_input.ToLower(), 0, i_input.Length-1);
            if (isPalindrome == true)
            {
                Console.WriteLine("Is Palindrome: Yes");
            }
            else
            {
                Console.WriteLine("Is Palindrome: No");
            }
        }

        private static bool isPalindromeRecursive(string i_input, int i_left, int i_right)
        {
            bool isEqual = false;

            if (i_left >= i_right) // break point 
            {
                isEqual = true;
            }
            else if(i_input[i_left] == i_input[i_right])
            {
                isEqual = isPalindromeRecursive(i_input, i_left + 1, i_right - 1);
            }

            return isEqual;
        }

        private static void countDividableBy3(long i_input)
        {
            if(i_input % 3 == 0)
            {
                Console.WriteLine("Is the number is divideble by 3: Yes");
            }
            else
            {
                Console.WriteLine("Is the number is divideble by 3: No");
            }

        }

        private static bool hasOnlyEnglishLetters(string i_input)
        {
            bool hasOnlyEnglishLetters = true;

            foreach(char charachter in i_input)
            {
                if(char.ToLower(charachter) < 'a' || char.ToLower(charachter) > 'z')
                {
                    hasOnlyEnglishLetters = false;
                    break;
                }
            }

            return hasOnlyEnglishLetters;
        }

        private static void countUppercaseLetters(string i_input)
        {
            int uppercaseCount = 0;

            foreach(char letter in i_input)
            {
                if (char.IsUpper(letter))
                {
                    uppercaseCount++;
                }
            }

            Console.WriteLine(string.Format("Number of uppercase Letters:{0}", uppercaseCount));
        }

        private static void isAscendingAlphabetically(string i_input)
        {
            string lowerCasedString;
            lowerCasedString = i_input.ToLower();

            for(int i = 1; i < lowerCasedString.Length; i++)
            {
                if(lowerCasedString[i] < lowerCasedString[i - 1])
                {
                    Console.WriteLine("Is in ascending Alphabetically order: No");
                    return;
                }
            }

            Console.WriteLine("Is in ascending Alphabetically order: Yes");
        }
    }
}
