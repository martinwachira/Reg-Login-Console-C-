using System;

namespace Fibonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int _firstnum = 0, _secondnum = 1, _nextNum, _elmsArray;
            Console.Write("Enter the number of desired elements : ");
            _elmsArray = int.Parse(Console.ReadLine());

            // implement error catch method here
            try
            {
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
            } catch
            {
                Console.WriteLine("Some Error Occured. Try again");
            }
        }
    }
}
