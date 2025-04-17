using System;
using System.Text;

namespace Ex01_02
{
    public class NumberTree
    {
        const int k_MaxNumber = 9;

        public static void PrintNumberTree(int i_numOfRows, int i_currentNumber, int i_currentRow)
        {
            if (i_currentRow > i_numOfRows - 2) // if we are in the stem
            {
                printStem(i_currentNumber, i_numOfRows);
                return;
            }
            else
            {
                printLevel(ref i_currentNumber, i_currentRow, i_numOfRows);
            }
            PrintNumberTree(i_numOfRows, i_currentNumber, i_currentRow + 1);
        }

        private static void printLevel(ref int io_currentNumber, int i_currentRow, int i_numOfRows)
        {
            StringBuilder row = new StringBuilder();
            char letter = numberToLetter(i_currentRow);

            int amountOfSpaces = (i_numOfRows * 2 - (i_currentRow - 1) * 2);
            string spaces = new string(' ', amountOfSpaces);

            row.Append(string.Format("{0}{1}", letter, spaces));

            for (int i = 0; i < ((i_currentRow - 1) * 2) + 1; i++) // amount of numbers to append in the row 
            {
                row.Append(string.Format("{0} ", io_currentNumber));

                calcNextNumber(ref io_currentNumber);
            }

            Console.WriteLine(row);
        }

        private static void printStem(int i_currentNumber, int i_numOfRows)
        {
            StringBuilder stem1 = new StringBuilder();
            StringBuilder stem2 = new StringBuilder();

            int amountOfSpaces = i_numOfRows * 2 - 1;
            string spaces = new string(' ', amountOfSpaces);


            stem1.Append(string.Format("{0}{1}|{2}|", numberToLetter(i_numOfRows - 1), spaces, i_currentNumber)); // the level bfore the last stem
            stem2.Append(string.Format("{0}{1}|{2}|", numberToLetter(i_numOfRows), spaces, i_currentNumber)); // the last stem 

            Console.WriteLine(stem1);
            Console.WriteLine(stem2);
        }

        private static void calcNextNumber(ref int io_number)
        {
            if (io_number == k_MaxNumber)
            {
                io_number = 1;
            }
            else
            {
                io_number++;
            }
        }

        private static char numberToLetter(int i_number)
        {
            return (char)('A' + i_number - 1);
        }
    }
}
