using System;

namespace Fibonacci_Sequence
{
    class Program
    {
        public void FibSeq()
        {
            int _firstnum = 0, _secondnum = 1, _nextNum, _elmsArray;

            // implement error catch method here
            try
            {
                Console.Write("Enter the number of desired elements : ");
                _elmsArray = int.Parse(Console.ReadLine());

                if (_elmsArray < 2)
                {
                    Console.Write("Please Enter a number greater than two");
                }
                else
                {
                    //First print first and second number
                    Console.Write(_firstnum + " " + _secondnum + " ");
                    //Starts the loop from 2 because 0 and 1 are already printed
                    for (int i = 2; i < _elmsArray; i++)
                    {
                        _nextNum = _firstnum + _secondnum;
                        Console.Write(_nextNum + " ");
                        _firstnum = _secondnum;
                        _secondnum = _nextNum;
                    }
                }
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Some Error Occured. Try again");
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.FibSeq();
        }
    }
}
