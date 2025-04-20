using System; 

namespace Ex01_03
{
    class Program
    {
        public static void Main() // Main entry point of the program
        {
            Console.WriteLine("Please Enter the level of the tree:"); // Prompt user to enter tree level

            const int k_MinValue = 4; // Minimum level value
            const int k_MaxValue = 15; // Maximum level value

            string input = Console.ReadLine(); // Read user input for the tree level
            int levels; // Variable to store the number of levels
            bool success; // Flag to check if parsing was successful

            success = int.TryParse(input, out levels); // Try to parse the input into an integer

            while (levels < k_MinValue || levels > k_MaxValue || success == false) // Check if the level is within the valid range
            {
                Console.WriteLine("Please Try Again The level should be between 4 and 15"); // Prompt if invalid
                input = Console.ReadLine(); // Read the input again
                success = int.TryParse(input, out levels); // Try parsing again
            }

            Ex01_02.Program.PrintNumberTree(levels, 1, 1); // Call PrintNumberTree from Ex01_02.Program with user-specified levels
        }
    }
}
