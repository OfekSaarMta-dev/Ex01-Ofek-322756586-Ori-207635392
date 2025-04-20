using System; 

namespace Ex01_04
{
    class Program
    {
        public static void Main() 
        {
            Console.WriteLine("Please enter a string that is exactly 12 characters long: "); // Prompt for string input
            string input = Console.ReadLine(); // Read the input string

            while (isValidInput(input) != true) // Check if input is valid (12 characters long)
            {
                Console.WriteLine("Invalid input. Try again."); // Prompt if invalid
                Console.WriteLine("Enter a 12-character string: ");
                input = Console.ReadLine(); // Read input again
            }

            checkIfPalindrome(input); // Check if the string is a palindrome

            long o_inputAsNumber;
            bool isANumber = long.TryParse(input, out o_inputAsNumber); // Try to parse input as a number

            if (isANumber == true) // If input is a valid number
            {
                countDividableBy3(o_inputAsNumber); // Check if number is divisible by 3
            }

            if (hasOnlyEnglishLetters(input) == true) // If input contains only English letters
            {
                countUppercaseLetters(input); // Count uppercase letters in the string
                isAscendingAlphabetically(input); // Check if letters are in ascending alphabetical order
            }

        }

        private static bool isValidInput(string i_input) // Checks if the input is exactly 12 characters long
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(i_input) || i_input.Length != 12) // If input is null or not 12 characters long
            {
                isValid = false; // Set valid to false
            }

            return isValid; // Return whether input is valid
        }

        private static void checkIfPalindrome(string i_input) // Checks if the string is a palindrome
        {
            bool isPalindrome = isPalindromeRecursive(i_input.ToLower(), 0, i_input.Length - 1); // Recursive check
            if (isPalindrome == true) // If it's a palindrome
            {
                Console.WriteLine("Is Palindrome: Yes"); // Output Yes
            }
            else
            {
                Console.WriteLine("Is Palindrome: No"); // Output No
            }
        }

        private static bool isPalindromeRecursive(string i_input, int i_left, int i_right) // Recursive helper to check for palindrome
        {
            bool isEqual = false;

            if (i_left >= i_right) // If left index meets or surpasses right, it's a palindrome
            {
                isEqual = true;
            }
            else if (i_input[i_left] == i_input[i_right]) // If characters match, check next pair
            {
                isEqual = isPalindromeRecursive(i_input, i_left + 1, i_right - 1); // Continue recursion
            }

            return isEqual; // Return result of palindrome check
        }

        private static void countDividableBy3(long i_input) // Checks if the number is divisible by 3
        {
            if (i_input % 3 == 0) // If divisible by 3
            {
                Console.WriteLine("Is the number is divideble by 3: Yes"); // Output Yes
            }
            else
            {
                Console.WriteLine("Is the number is divideble by 3: No"); // Output No
            }
        }

        private static bool hasOnlyEnglishLetters(string i_input) // Checks if the input contains only English letters
        {
            bool hasOnlyEnglishLetters = true;

            foreach (char charachter in i_input) // Iterate through each character
            {
                if (char.ToLower(charachter) < 'a' || char.ToLower(charachter) > 'z') // If it's not an English letter
                {
                    hasOnlyEnglishLetters = false; // Set to false
                    break; // Exit loop
                }
            }

            return hasOnlyEnglishLetters; // Return result
        }

        private static void countUppercaseLetters(string i_input) // Counts the number of uppercase letters in the string
        {
            int uppercaseCount = 0;

            foreach (char letter in i_input) // Iterate through each character
            {
                if (char.IsUpper(letter)) // If the character is uppercase
                {
                    uppercaseCount++; // Increment the count
                }
            }

            Console.WriteLine(string.Format("Number of uppercase Letters:{0}", uppercaseCount)); // Output the count
        }

        private static void isAscendingAlphabetically(string i_input) // Checks if the string's letters are in ascending order
        {
            string lowerCasedString;
            lowerCasedString = i_input.ToLower(); // Convert input to lowercase for comparison

            for (int i = 1; i < lowerCasedString.Length; i++) // Iterate through each character starting from the second one
            {
                if (lowerCasedString[i] < lowerCasedString[i - 1]) // If current character is less than previous
                {
                    Console.WriteLine("Is in ascending Alphabetically order: No"); // Output No
                    return; // Exit method
                }
            }

            Console.WriteLine("Is in ascending Alphabetically order: Yes"); // Output Yes
        }
    }
}
