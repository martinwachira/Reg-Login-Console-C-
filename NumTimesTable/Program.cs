using System;

namespace NumTimesTable
{
    class Program
    {
        // declare variables to hold the number to be multiplied and the range of multiplication
        int num, range;

        public void MultiplyNums()
        {
            // try-catch methods to handle errors
            try
            {
                Console.Write("Enter a Number to multiply: ");
                num = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the length of numbers you want multiplied: ");
                range = Convert.ToInt32(Console.ReadLine());

                // loop through the numbers in the range and return the result
                for (int i = 1; i <= range; i++)
                {
                    Console.WriteLine("{0}*{1}={2}", num, i, num * i);
                }
            }
            catch
            {
                Console.Write("Some Error Occured, please try again.");
            }
        }
        static void Main(string[] args)
        {
            bool done = false;
            // creating objects of Program Class
            Program prog = new Program();

            // allows user to run the program multiple times
            while (!done)
            {
                // call MultiplyNums method
                prog.MultiplyNums();
                Console.WriteLine("\n ********************************************************************* \n");
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
