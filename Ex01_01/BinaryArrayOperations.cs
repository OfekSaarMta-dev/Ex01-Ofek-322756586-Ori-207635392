
using System;
using System.Text;
using System.Linq;

namespace Ex01_01
{
    class BinaryArrayOperations
    {

        public static void PrintBinaryStrings(BinaryNumber[] i_binaryNumbersArray)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < i_binaryNumbersArray.Length - 1; i++) 
            {
                output.Append(string.Format("{0}, ", i_binaryNumbersArray[i].GetBinaryString()));
            }

            output.Append(string.Format("{0}", i_binaryNumbersArray[i_binaryNumbersArray.Length - 1].GetBinaryString())); // to prevent the last ","

            Console.WriteLine("\n");
            Console.WriteLine(output);
        }

        public static void PrintSortedDecimalValues(BinaryNumber[] i_binaryNumbersArray)
        {
            Array.Sort(i_binaryNumbersArray, (a, b) => (a.GetDecimalValue().CompareTo(b.GetDecimalValue())));

            StringBuilder output = new StringBuilder();

            output.Append("Decimal values in descending order: ");

            for(int i = i_binaryNumbersArray.Length - 1; i > 0; i--)
            {
                output.Append(string.Format("{0}, ", i_binaryNumbersArray[i].GetDecimalValue()));
            }

            output.Append(string.Format("{0}, ", i_binaryNumbersArray[0].GetDecimalValue()));

            Console.WriteLine(output);
        }

        public static void PrintAverage(BinaryNumber[] i_binaryNumbersArray)
        {
            float sumOfDecimalValues = 0;
            float average;

            for (int i = 0; i < i_binaryNumbersArray.Length; i++)
            {
                sumOfDecimalValues += i_binaryNumbersArray[i].GetDecimalValue();
            }

            average = sumOfDecimalValues / (float)i_binaryNumbersArray.Length;

            Console.WriteLine(string.Format("- Average of decimal values: {0:F2}", average)); // displaying 2 numbers after the floating point
        }

        public static void PrintLongestOnesSequence(BinaryNumber[] i_binaryNumbersArray)
        {
            int maxSequence = 0;
            string binaryWithLongestSequence = "";

            foreach (BinaryNumber binaryNumber in i_binaryNumbersArray)
            {
                int currentSequence = binaryNumber.GetLongestOnesSequence();

                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                    binaryWithLongestSequence = binaryNumber.GetBinaryString();
                }
            }

            Console.WriteLine(string.Format("- Longest sequence of 1s: {0} (from number {1})", maxSequence, binaryWithLongestSequence));
        }

        public static void PrintTransitionsOf0And1(BinaryNumber[] i_binaryNumbersArray)
        {
            StringBuilder output = new StringBuilder();

            output.Append("- Number of transitions: ");

            int transitions;
            string binaryString;

            for (int i = 0; i < i_binaryNumbersArray.Length - 1; i++)
            {
                transitions = i_binaryNumbersArray[i].GetNumberOfChangesBetween0And1();
                binaryString = i_binaryNumbersArray[i].GetBinaryString();

               output.Append(string.Format("{0} ({1}), ", transitions, binaryString));
            }

            transitions = i_binaryNumbersArray[i_binaryNumbersArray.Length - 1].GetNumberOfChangesBetween0And1();
            binaryString = i_binaryNumbersArray[i_binaryNumbersArray.Length - 1].GetBinaryString();

            output.Append(string.Format("{0} ({1})", transitions, binaryString));

            Console.WriteLine(output);
        }

        public static void PrintNumberWithMostOnes(BinaryNumber[] i_binaryNumbersArray)
        {
            StringBuilder output = new StringBuilder();


            int maxOnesCount = 0;
            string binaryWithMostOnes = "";
            int decimalValueOfBinaryWithMostOnes = 0;

            foreach (BinaryNumber binaryNumber in i_binaryNumbersArray)
            {
                int currentOnesCount = binaryNumber.GetOnesCount();
                if (currentOnesCount > maxOnesCount)
                {
                    maxOnesCount = currentOnesCount;
                    binaryWithMostOnes = binaryNumber.GetBinaryString();
                    decimalValueOfBinaryWithMostOnes = binaryNumber.GetDecimalValue();
                }
            }

            output.Append(string.Format("- Number with the most 1s: {0} (binary: {1})", decimalValueOfBinaryWithMostOnes, binaryWithMostOnes));

            foreach (BinaryNumber binaryNumber in i_binaryNumbersArray)
            {
                int currentOnesCount = binaryNumber.GetOnesCount();
                if (currentOnesCount == maxOnesCount && binaryNumber.GetBinaryString() != binaryWithMostOnes)
                {
                    output.Append(string.Format(" (or {0} (both with {1})", decimalValueOfBinaryWithMostOnes, maxOnesCount));
                }
            }

            Console.WriteLine(output);
        }

        public static void PrintTotalOnesCount(BinaryNumber[] binaryNumbersArray)
        {
            int totalOnesCount = 0;

            foreach (BinaryNumber binaryNumber in binaryNumbersArray)
            {
                totalOnesCount += binaryNumber.GetOnesCount();
            }

            Console.WriteLine(string.Format("- Total count of 1s: {0}", totalOnesCount));
        }
    }
}
