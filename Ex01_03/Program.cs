using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex01_02;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please Enter the level of the tree:");

            const int k_MinValue = 4;
            const int k_MaxValue = 15;

            string input = Console.ReadLine();
            int levels;
            bool success;

            success = int.TryParse(input, out levels);

            while(levels < k_MinValue || levels > k_MaxValue || success == false)
            {
                Console.WriteLine("Please Try Again The level should be between 4 and 15");
                input = Console.ReadLine();
                success = int.TryParse(input, out levels);
            }

            NumberTree.PrintNumberTree(levels, 1, 1);
            Console.ReadLine();
        }
    }
}
