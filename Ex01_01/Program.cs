using System; 
using System.Linq; 
using System.Text; // Used for StringBuilder operations

namespace Ex01_01 
{
    class Program // Main class
    {
        const int k_NumOfBinaryNumbers = 4; // Constant for the number of binary numbers to input

        public static void Main() // Entry point of the program
        {
            string input; // To store each input string
            string[] binaryStringArray = new string[k_NumOfBinaryNumbers]; // Stores input binary strings
            int[] decimalValuesArray = new int[k_NumOfBinaryNumbers]; // Stores converted decimal values
            int[] longestOnesSequencesArray = new int[k_NumOfBinaryNumbers]; // Stores max 1s sequence for each input
            int[] onesCountsArray = new int[k_NumOfBinaryNumbers]; // Stores total number of 1s in each input
            int[] numberOfChangesArray = new int[k_NumOfBinaryNumbers]; // Stores transitions count between 0 and 1

            Console.WriteLine("Please Enter a 4 binary numbers with 7 digits each"); 

            for (int i = 0; i < k_NumOfBinaryNumbers; i++) // Loop to collect and process each input
            {
                input = Console.ReadLine(); // Read input from user
                while (isBinaryNameValid(input) != true) // Validate input
                {
                    Console.WriteLine("Input is invalid, please try again"); // if invalid
                    input = Console.ReadLine(); // Re-read input
                }

                binaryStringArray[i] = input; // Save input
                decimalValuesArray[i] = convertBinaryToDecimal(int.Parse(input)); // Convert binary to decimal
                longestOnesSequencesArray[i] = longestOnesSequence(input); // Get longest 1s sequence
                onesCountsArray[i] = numberOfOnes(input); // Count number of 1s
                numberOfChangesArray[i] = numberOfChangesBetween0And1(input); // Count transitions
            }

            printBinaryStrings(binaryStringArray); // Print all binary inputs
            printSortedDecimalValues(decimalValuesArray); // Print sorted decimal values
            printAverage(decimalValuesArray); // Print average of decimal values
            printLongestOnesSequence(binaryStringArray, longestOnesSequencesArray); // Print max 1s sequence
            printTransitionsOf0And1(binaryStringArray, numberOfChangesArray); // Print transitions
            printNumberWithMostOnes(binaryStringArray, onesCountsArray, decimalValuesArray); // Print number with most 1s
            printTotalOnesCount(onesCountsArray); // Print total 1s count
            Console.ReadLine();
        }

        private static bool isBinaryNameValid(string i_inputString) // Validate if string is binary with 7 characters
        {
            bool isValid = true; // Default to true

            if (string.IsNullOrEmpty(i_inputString) && i_inputString.Length >= 7) // Check null and length
            {
                isValid = false; // Invalid if condition met
            }

            foreach (char charachter in i_inputString) // Check each character
            {
                if (charachter != '0' && charachter != '1') // Must be 0 or 1
                {
                    isValid = false; // Invalid character
                    break; // Exit loop early
                }
            }
            return isValid; // Return result
        }

        private static int convertBinaryToDecimal(int i_binaryInt) // Converts a binary number (as int) to its decimal representation using Math.Pow
        {
            int decimalValue = 0; // Final result to return
            int position = 0; // Tracks the bit position (starting from right)

            while (i_binaryInt > 0) // Loop through each digit of the binary number
            {
                int lastDigit = i_binaryInt % 10; // Extract the last digit
                i_binaryInt /= 10; // Remove the last digit from the number

                decimalValue += lastDigit * (int)Math.Pow(2, position); // Convert binary digit to decimal and add it, using Math.Pow
                position++; // Move to the next bit position
            }

            return decimalValue; // Return the computed decimal value
        }


        private static int longestOnesSequence(string i_input) // Finds max sequence of consecutive 1s
        {
            int onesSequence = 0; // Current sequence length
            int maxOnesSequence = 0; // Max sequence found

            foreach (char charachter in i_input) // Loop through each bit
            {
                if (charachter == '1') // If 1, increment sequence
                {
                    onesSequence++;
                    if (onesSequence > maxOnesSequence) // Update max if needed
                    {
                        maxOnesSequence = onesSequence;
                    }
                }
                else // if charachter equals '0' stop sequence
                {
                    onesSequence = 0; // Reset counter
                }
            }

            return maxOnesSequence; // Return result
        }

        private static int numberOfOnes(string i_input) // Counts total number of 1s in the input
        {
            int onesCounter = 0; // Counter for 1s

            foreach (char charachter in i_input) // Loop through characters
            {
                if (charachter == '1') // Check for 1
                {
                    onesCounter++; // Increment counter
                }
            }
            return onesCounter; // Return count
        }

        private static int numberOfChangesBetween0And1(string i_input) // Counts bit transitions
        {
            int changesCounter = 0; // Counter for changes

            for (int i = 1; i < i_input.Length; i++) // Start from second character
            {
                if (i_input[i] != i_input[i - 1]) // If current character is different from the previous one
                {
                    changesCounter++; // Increment changes
                }
            }

            return changesCounter; // Return count
        }

        private static void printBinaryStrings(string[] i_binaryStringArray) // Prints all input binary strings
        {
            StringBuilder output = new StringBuilder(); // Efficient string builder

            for (int i = 0; i < i_binaryStringArray.Length - 1; i++) // Loop excluding last element
            {
                output.Append(string.Format("{0}, ", i_binaryStringArray[i])); // Append with comma
            }

            output.Append(string.Format("{0}", i_binaryStringArray[i_binaryStringArray.Length - 1])); // to prevent the last ","

            Console.WriteLine("\n"); // Print line break
            Console.WriteLine(output); // Print result
        }

        private static void printSortedDecimalValues(int[] i_decimalNumbersArray) // Prints decimal values sorted descending
        {
            int[] decimalValues = new int[i_decimalNumbersArray.Length]; // Copy array

            for (int i = 0; i < i_decimalNumbersArray.Length; i++) // Copy values
            {
                decimalValues[i] = i_decimalNumbersArray[i];
            }

            Array.Sort(decimalValues); // Sort ascending

            StringBuilder output = new StringBuilder();

            output.Append("Decimal values in descending order: "); 

            for (int i = i_decimalNumbersArray.Length - 1; i > 0; i--) // Loop in reverse
            {
                output.Append(string.Format("{0}, ", decimalValues[i])); // Append with comma
            }

            output.Append(string.Format("{0}", decimalValues[0])); // Append last value

            Console.WriteLine(output); // Print result
        }

        private static void printAverage(int[] i_decimalNumbersArray) // Calculates and prints average
        {
            float sumOfDecimalValues = 0; // Sum accumulator
            float average; // Average result

            for (int i = 0; i < i_decimalNumbersArray.Length; i++) // Sum values
            {
                sumOfDecimalValues += i_decimalNumbersArray[i];
            }

            average = sumOfDecimalValues / (float)i_decimalNumbersArray.Length; // Compute average

            Console.WriteLine(string.Format("- Average of decimal values: {0:F1}", average)); // displaying 2 numbers after the floating point
        }

        private static void printLongestOnesSequence(string[] i_binaryStringArray, int[] i_longestOnesSequence) // Prints binary string with longest 1s sequence
        {
            int maxSequence = 0; // Track max sequence
            string binaryWithLongestSequence = ""; // Store corresponding binary string

            for (int i = 0; i < i_binaryStringArray.Length; i++) // Loop through all
            {
                if (i_longestOnesSequence[i] > maxSequence) // Compare with max
                {
                    maxSequence = i_longestOnesSequence[i];
                    binaryWithLongestSequence = i_binaryStringArray[i];
                }
            }

            Console.WriteLine(string.Format("- Longest sequence of 1s: {0} (from number {1})", maxSequence, binaryWithLongestSequence));
        }

        private static void printTransitionsOf0And1(string[] i_binrayStringArray, int[] i_numberOfChangesArray) // Prints number of transitions per binary
        {
            StringBuilder output = new StringBuilder(); // Build output string

            output.Append("- Number of transitions: "); 

            int transitions; // Store transitions
            string binaryString; // Store current binary

            for (int i = 0; i < i_binrayStringArray.Length - 1; i++) // Loop except last
            {
                transitions = i_numberOfChangesArray[i];
                binaryString = i_binrayStringArray[i];

                output.Append(string.Format("{0} ({1}), ", transitions, binaryString)); // Append entry
            }

            transitions = i_numberOfChangesArray[i_numberOfChangesArray.Length - 1]; // Last transition
            binaryString = i_binrayStringArray[i_binrayStringArray.Length - 1]; // Last binary

            output.Append(string.Format("{0} ({1})", transitions, binaryString)); // Append final entry

            Console.WriteLine(output); // Print result
        }

        private static void printNumberWithMostOnes(string[] i_binaryStringArray, int[] i_onesCountsArray, int[] i_decimalNumbersArray) // Print binary with most 1s and decimal
        {
            StringBuilder output = new StringBuilder(); // Build result string

            int maxOnesCount = 0; // Track max 1s
            string binaryStringWithMostOnes = ""; // Track binary with most 1s
            int decimalValueOfBinaryWithMostOnes = 0; // Corresponding decimal value

            for (int i = 0; i < i_binaryStringArray.Length; i++) // Find max
            {
                if (i_onesCountsArray[i] > maxOnesCount)
                {
                    maxOnesCount = i_onesCountsArray[i];
                    binaryStringWithMostOnes = i_binaryStringArray[i];
                    decimalValueOfBinaryWithMostOnes = i_decimalNumbersArray[i];
                }
            }

            output.Append(string.Format("- Number with the most 1s: {0} (binary: {1})", decimalValueOfBinaryWithMostOnes, binaryStringWithMostOnes));

            for (int i = 0; i < i_binaryStringArray.Length; i++) // Check for ties
            {
                if (i_onesCountsArray[i] == maxOnesCount && i_binaryStringArray[i] != binaryStringWithMostOnes)
                {
                    output.Append(string.Format(" (or {0} (both with {1})) ", i_decimalNumbersArray[i], maxOnesCount));
                }
            }

            Console.WriteLine(output); // Print result
        }

        private static void printTotalOnesCount(int[] i_onesCountsArray) // Prints total number of 1s from all inputs
        {
            int totalOnesCount = 0; // Accumulator

            foreach (int onesCount in i_onesCountsArray) // Loop through counts
            {
                totalOnesCount += onesCount; // Add to total
            }

            Console.WriteLine(string.Format("- Total count of 1s: {0}", totalOnesCount)); // Print result
        }
    }
}
