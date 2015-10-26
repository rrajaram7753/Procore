using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfEratosthenes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Give an integer to generate Sieve Of Eratosthenes and press 'Enter'");
            var input = Convert.ToInt32(Console.ReadLine());

            //Make a list of all integers from 2 upto the given input 
            var inputList = new List<int>();
            for (int i = 2; i <= input; i++)
                inputList.Add(i);

            var output = SOE_Impl(inputList, input);

            Console.WriteLine("Prime numbers are....");
            foreach (var value in output)
                Console.WriteLine(value);
            Console.ReadLine();
        }

        /// <summary>
        /// Consider n is the integer below which Prime Numbers are to be found
        /// loop from 2 (take it as p) until SquareRoot of n
        /// find increments of p
        /// flag them as 'not prime'
        /// remove them from the list
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="maxValueInList"></param>
        /// <returns></returns>
        public static List<int> SOE_Impl(List<int> inputList, int maxValueInList)
        {
            var sqRootOfInput = (int)Math.Sqrt(maxValueInList);
            var markedToDelete = new List<int>();

            foreach(var currNum in inputList)
            {
                if (currNum > sqRootOfInput)
                    break;
                if (markedToDelete.Contains(currNum))
                    continue;

                int incCounter = currNum;
                while (incCounter < maxValueInList)
                {
                    markedToDelete.Add(currNum + incCounter);
                    incCounter = incCounter + currNum;
                }
            }
            inputList.RemoveAll(x => markedToDelete.Contains(x));
            return inputList;
        }
    }
}
