using System;

namespace Week5ChallengeLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            // This boolean controls the entire menu loop.
            // When I set this to false, the program stops running.
            var running = true;

            while (running)
            {
                Console.Clear();

                // Menu layout using only ASCII characters.
                Console.WriteLine("---------------------------");
                Console.WriteLine("      WEEK 5 CHALLENGE     ");
                Console.WriteLine("           LABS MENU       ");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Single Number (XOR Problem)");
                Console.WriteLine("2. Missing Number (Gauss Formula)");
                Console.WriteLine("3. Run All Test Cases");
                Console.WriteLine("0. Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunSingleNumber();
                        break;

                    case "2":
                        RunMissingNumber();
                        break;

                    case "3":
                        RunAllTests();
                        break;

                    case "0":
                        running = false; // This exits the loop and ends the program.
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Press Enter.");
                        Console.ReadLine();
                        break;
                }
            }

           
        }

        // ---------------------------------------------------------
        // PROBLEM 1: Single Number (XOR)
        // ---------------------------------------------------------
        static int SingleNumber(int[] nums)
        {
            // I start with result = 0 because XOR with 0 gives me the number itself.
            // Example: 0 XOR 5 = 5
            var result = 0;

            // I loop through every number in the array.
            // XOR has a special property:
            // - If I XOR a number with itself, it becomes 0.
            // - If I XOR 0 with a number, I get the number.
            // - Duplicates cancel out.
            // So the only number left at the end is the one that does NOT have a duplicate.
            foreach (var num in nums)
            {
                result ^= num; // This is where duplicates cancel each other out.
            }

            // Whatever is left in result is the single number.
            return result;
        }

        static void RunSingleNumber()// This method runs all the test cases for the Single Number problem.
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("     Single Number (XOR)   ");
            Console.WriteLine("---------------------------");

            // All test cases required by the assignment.
            var testCases = new[]
            {
                new[] { 2, 2, 1 },
                new[] { 4, 1, 2, 1, 2 },
                new[] { 1 }
            };

            foreach (var test in testCases) //loop through each to display input and output
            {
                Console.Write("Input: [");
                Console.Write(string.Join(",", test));
                Console.WriteLine("]");

                // I call my XOR method to get the answer.
                Console.WriteLine("Output: " + SingleNumber(test));
                Console.WriteLine("---------------------------");
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }

        // ---------------------------------------------------------
        // PROBLEM 2: Missing Number (Gauss Formula)
        // ---------------------------------------------------------
        static int MissingNumber(int[] nums)
        {
            // The array length tells me what the range SHOULD be.
            // Example: nums length = 3 means the numbers should be 0,1,2,3.
            var n = nums.Length;

            // I use the Gauss formula to calculate the sum of all numbers from 0 to n.
            // Formula: n * (n + 1) / 2
            // This gives me the sum IF nothing was missing.
            var expectedSum = n * (n + 1) / 2;

            // Now I calculate the actual sum of the numbers that ARE in the array.
            var actualSum = 0;

            foreach (var num in nums)
            {
                actualSum += num;
            }

            // The missing number is simply the difference.
            // Example:
            // expected = 6
            // actual = 4
            // missing = 2
            return expectedSum - actualSum;
        }

        static void RunMissingNumber()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("       Missing Number      ");
            Console.WriteLine("---------------------------");

            // All required test cases.
            var testCases = new[]
            {
                new[] { 3, 0, 1 },
                new[] { 0, 1 },
                new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }
            };

            foreach (var test in testCases)//loop through each to display input and output
            {
                Console.Write("Input: [");
                Console.Write(string.Join(",", test));
                Console.WriteLine("]");

                Console.WriteLine("Output: " + MissingNumber(test));
                Console.WriteLine("---------------------------");
            }

            Console.WriteLine("Press Enter to return to menu.");
            Console.ReadLine();
        }

        // ---------------------------------------------------------
        // RUN ALL TEST CASES
        // ---------------------------------------------------------
        static void RunAllTests()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("     Running All Tests     ");
            Console.WriteLine("---------------------------\n");

            Console.WriteLine("Single Number Tests:");
            Console.WriteLine("[2,2,1] = " + SingleNumber(new[] { 2, 2, 1 }));
            Console.WriteLine("[4,1,2,1,2] = " + SingleNumber(new[] { 4, 1, 2, 1, 2 }));
            Console.WriteLine("[1] = " + SingleNumber(new[] { 1 }));

            Console.WriteLine("\n---------------------------");

            Console.WriteLine("Missing Number Tests:");
            Console.WriteLine("[3,0,1] = " + MissingNumber(new[] { 3, 0, 1 }));
            Console.WriteLine("[0,1] = " + MissingNumber(new[] { 0, 1 }));
            Console.WriteLine("[9,6,4,2,3,5,7,0,1] = " + MissingNumber(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }));

            Console.WriteLine("\nPress Enter to return to menu.");
            Console.ReadLine();
            
        }
    }
}
