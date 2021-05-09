using System;

namespace NumsFactorial
{
    class Program
    {
        public void FactorialMethod()
        {
            int x, num, facNum;
            Console.WriteLine("Enter Number to get it's Factorial: ");
            num = Convert.ToInt32(Console.ReadLine());
            facNum = num;

            for (x = num - 1; x>=1; x--)
            {
                facNum = facNum * x;
            }
                Console.WriteLine(facNum);
            Console.WriteLine(" \n *************************************************");
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            try
            {
                string inputMsg;
                Console.Clear();
                prog.FactorialMethod();
                Console.WriteLine("Do you want to Quit? \n 1. No \n 2. Yes \n");
                inputMsg = Console.ReadLine();
                //if(inputMsg == "No")
                //{
                //    prog.FactorialMethod();
                //    Console.Clear();
                //}else if(inputMsg == "Yes")
                //{
                //    Console.Write("Logging out...");
                //}
                //else
                //{
                //    Console.WriteLine("Error");
                //    Console.ReadKey();
                //}

                // while loop
                //while (inputMsg == "No")
                //{
                //    prog.FactorialMethod();
                //}

                switch (inputMsg)
                {
                    case "No":
                        prog.FactorialMethod();
                        break;
                    case "Yes":
                        Console.WriteLine("Logging out... ");
                        break;
                    default:
                        Console.WriteLine("logged out");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error occured. Please try again");
            }
        }
    }
}
