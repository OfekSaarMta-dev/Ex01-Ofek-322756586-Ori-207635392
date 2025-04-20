using System; // For basic input/output functionality

namespace Ex01_05
{
    class Program
    {
        public static void Main() // Main entry point of the program
        {
            const int k_InputLength = 8; // Constant for the valid input length (8 digits)

            Console.WriteLine("Please enter a 8 digits number: "); 
            string input = Console.ReadLine(); // Read input string
            int inputAsNumber;

            while (isValidInput(input, k_InputLength) != true || int.TryParse(input, out inputAsNumber) != true) // Check if the input is valid
            {
                Console.WriteLine("Invalid input. Try again."); 
                Console.WriteLine("Please enter a 8 digits number: ");
                input = Console.ReadLine(); // Read input again
            }

            howManyDigitsSmallerThanTheFirstDigit(input); // Count digits smaller than the first digit
            howManyDividableBy3(input); // Count digits divisible by 3
            maxAndMinDigitsDifference(input); // Find the difference between the max and min digits
            mostFrequentDigit(input); // Find the most frequent digit

            Console.ReadLine(); // Keep the console open until the user presses Enter
        }

        private static bool isValidInput(string i_input, int i_validLength) // Validates the input
        {
            bool isValid = true;

            if (i_input[0] == '-') // If input starts with a negative sign, it's invalid
            {
                isValid = false;
            }

            if (string.IsNullOrEmpty(i_input) || i_input.Length != i_validLength) // If input is empty or not the correct length
            {
                isValid = false; // Set to invalid
            }

            return isValid; // Return whether input is valid
        }

        private static void howManyDigitsSmallerThanTheFirstDigit(string i_inputAsString) // Counts digits smaller than the first digit
        {
            int amountOfNumbersSmallerThanTheFirstDigit = 0;

            for (int i = 1; i < i_inputAsString.Length; i++) // Loop through the digits (excluding the first)
            {
                if (i_inputAsString[i] < i_inputAsString[0]) // If the digit is smaller than the first digit
                {
                    amountOfNumbersSmallerThanTheFirstDigit++; // Increment the count
                }
            }

            Console.WriteLine(string.Format("The left Digit is: {0}. Digits smaller than it (excluding the first): {1}"
                , i_inputAsString[0], amountOfNumbersSmallerThanTheFirstDigit)); // Output the result
        }

        private static void howManyDividableBy3(string i_inputAsString) // Counts digits divisible by 3
        {
            int amountOfNumbersDividableBy3 = 0;

            foreach (char digit in i_inputAsString) // Iterate through each character (digit)
            {
                if ((digit - '0') % 3 == 0) // If the digit is divisible by 3
                {
                    amountOfNumbersDividableBy3++; // Increment the count
                }
            }

            Console.WriteLine(string.Format("Digits divisible By 3: {0}", amountOfNumbersDividableBy3)); // Output the result
        }

        private static void maxAndMinDigitsDifference(string i_inputAsString) // Finds the difference between the max and min digits
        {
            int min = i_inputAsString[0] - '0'; // Set initial min and max as the first digit
            int max = min;

            int currentDigit;

            foreach (char digit in i_inputAsString) // Iterate through each digit
            {
                currentDigit = digit - '0'; // Convert the character to its numeric value

                if (currentDigit < min) // If current digit is smaller than the min
                {
                    min = currentDigit; // Update min
                }
                if (currentDigit > max) // If current digit is larger than the max
                {
                    max = currentDigit; // Update max
                }
            }

            Console.WriteLine(string.Format("Difference: {0}", max - min)); // Output the difference
        }

        private static void mostFrequentDigit(string i_inputAsString) // Finds the most frequent digit
        {
            int mostFrequentDigit = i_inputAsString[0] - '0'; // Initialize most frequent digit
            int maxAppearance = 0; // Initialize max appearance count

            for (char digit = '0'; digit <= '9'; digit++) // Loop through each digit (0-9)
            {
                int count = 0;

                foreach (char charachter in i_inputAsString) // Count occurrences of the current digit
                {
                    if (charachter == digit) // If the character matches the current digit
                    {
                        count++; // Increment the count
                    }
                }

                if (count > maxAppearance) // If this digit appears more than the current max
                {
                    mostFrequentDigit = digit - '0'; // Update most frequent digit
                    maxAppearance = count; // Update the count of appearances
                }
            }

            Console.WriteLine(string.Format("Most frequent digit: {0} (appears {1} times)", mostFrequentDigit, maxAppearance)); // Output the result
        }
    }
}
