using System;
using System.Linq;

//ToDo:
// use a copy to sort or sort to a new array 
//
//
//

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
            const int k_NumOfBinaryNumbers = 4;
            string input;

            BinaryNumber[] binaryNumbersArray = new BinaryNumber[k_NumOfBinaryNumbers];

            for (int i = 0; i < k_NumOfBinaryNumbers; i++)
            {
                binaryNumbersArray[i] = new BinaryNumber();
            }

            Console.WriteLine("Please Enter a 4 binary numbers with 7 digits each");

            for(int i = 0; i < k_NumOfBinaryNumbers; i++)
            {
                input = Console.ReadLine();
                while(BinaryNumber.IsBinaryNameValid(input) != true)
                {
                    Console.WriteLine("Input is invalid, please try again");
                    input = Console.ReadLine();
                }

                binaryNumbersArray[i].Update(input);
            }

            BinaryArrayOperations.PrintBinaryStrings(binaryNumbersArray);
            BinaryArrayOperations.PrintSortedDecimalValues(binaryNumbersArray);
            BinaryArrayOperations.PrintAverage(binaryNumbersArray);
            BinaryArrayOperations.PrintLongestOnesSequence(binaryNumbersArray);
            BinaryArrayOperations.PrintTransitionsOf0And1(binaryNumbersArray);
            BinaryArrayOperations.PrintNumberWithMostOnes(binaryNumbersArray);
            BinaryArrayOperations.PrintTotalOnesCount(binaryNumbersArray);
        }
    }
}
