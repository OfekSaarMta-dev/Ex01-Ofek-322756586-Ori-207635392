using System; 
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        public static void Main() 
        {
            PrintNumberTree(7, 1, 1); // Prints a number tree with 7 rows, starting with number 1, and starting at row 1
        }

        const int k_MaxNumber = 9; // Maximum number in the tree

        public static void PrintNumberTree(int i_numOfRows, int i_currentNumber, int i_currentRow) // Recursive function to print the tree
        {
            if (i_currentRow > i_numOfRows - 2) // If we are at the stem (last row)
            {
                printStem(i_currentNumber, i_numOfRows); // Print the stem
                return; // Exit recursion
            }
            else
            {
                printLevel(ref i_currentNumber, i_currentRow, i_numOfRows); // Print the current level of the tree
            }
            PrintNumberTree(i_numOfRows, i_currentNumber, i_currentRow + 1); // Recursive call to print the next row
        }

        private static void printLevel(ref int io_currentNumber, int i_currentRow, int i_numOfRows) // Prints a single level of the tree
        {
            StringBuilder row = new StringBuilder(); // StringBuilder to build the row

            char letter = numberToLetter(i_currentRow); // Get the letter corresponding to the current row

            int amountOfSpaces = (i_numOfRows * 2 - (i_currentRow - 1) * 2); // Calculate spaces before numbers
            string spaces = new string(' ', amountOfSpaces); // Create a string of spaces

            row.Append(string.Format("{0}{1}", letter, spaces)); // Append letter and spaces to the row

            for (int i = 0; i < ((i_currentRow - 1) * 2) + 1; i++) // Loop to append the numbers for the current row
            {
                row.Append(string.Format("{0} ", io_currentNumber)); // Append the current number to the row

                calcNextNumber(ref io_currentNumber); // Update the current number
            }

            Console.WriteLine(row); // Print the current row
        }

        private static void printStem(int i_currentNumber, int i_numOfRows) // Prints the stem of the tree
        {
            StringBuilder stem1 = new StringBuilder(); // StringBuilder for the first stem line
            StringBuilder stem2 = new StringBuilder(); // StringBuilder for the second stem line

            int amountOfSpaces = i_numOfRows * 2 - 1; // Calculate spaces before the stem
            string spaces = new string(' ', amountOfSpaces); // Create a string of spaces

            stem1.Append(string.Format("{0}{1}|{2}|", numberToLetter(i_numOfRows - 1), spaces, i_currentNumber)); // Format first stem line
            stem2.Append(string.Format("{0}{1}|{2}|", numberToLetter(i_numOfRows), spaces, i_currentNumber)); // Format second stem line

            Console.WriteLine(stem1); // Print first stem line
            Console.WriteLine(stem2); // Print second stem line
        }

        private static void calcNextNumber(ref int io_number) // Calculate the next number, cycling from 1 to k_MaxNumber
        {
            if (io_number == k_MaxNumber) // If we've reached the max number, reset to 1
            {
                io_number = 1;
            }
            else
            {
                io_number++; // Otherwise, increment the number
            }
        }

        private static char numberToLetter(int i_number) // Converts a number to a corresponding letter
        {
            return (char)('A' + i_number - 1); // Convert number to letter ('A' is the starting letter)
        }
    }
}
