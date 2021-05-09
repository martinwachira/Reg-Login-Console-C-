using System;

namespace NumsFactorial
{
    class Program
    {
        // declare a method to calculate the factorials
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

            // implement error handling here
            try
            {
                string inputMsg;
                prog.FactorialMethod();
                Console.WriteLine("Do you want to Quit? \n 1. No \n 2. Yes \n");
                inputMsg = Console.ReadLine();

                switch (inputMsg)
                {
                    case "No":
                        prog.FactorialMethod();
                        do
                        {
                            Console.WriteLine("Do you want to Quit? \n 1. No \n 2. Yes \n");
                            inputMsg = Console.ReadLine();
                            if(inputMsg == "No")
                            {
                                prog.FactorialMethod();
                            }
                        }
                        while (inputMsg == "No");
                        if(inputMsg == "Yes"){
                            Console.WriteLine("You're being loged out, Thanks for using this Program... ");
                        }
                        break;
                    case "Yes":
                        Console.WriteLine("Logging out... ");
                        break;
                    default:
                        Console.WriteLine("Unknown input, Please try again");
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
