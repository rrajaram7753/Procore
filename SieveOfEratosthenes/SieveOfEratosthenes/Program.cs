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

            //var output = SOE_Impl1(inputList, input);
            //var output = SOE_Impl2(inputList, input);
            var output = SOE_Impl3(inputList, input);

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
        public static List<int> SOE_Impl1(List<int> inputList, int maxValueInList)
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

        /// <summary>
        /// to refine further, loop only until n/p
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="maxValueInList"></param>
        /// <returns></returns>
        public static List<int> SOE_Impl2(List<int> inputList, int maxValueInList)
        {
            var sqRootOfInput = (int)Math.Sqrt(maxValueInList);
            var markedToDelete = new List<int>();

            foreach (var currNum in inputList)
            {
                if (currNum > sqRootOfInput)
                    break;

                var exitAfter = (maxValueInList / currNum); // will further reduce the number of loops 

                if (markedToDelete.Contains(currNum))
                    continue;

                int incCounter = currNum;
                while (incCounter <= exitAfter)
                {
                    markedToDelete.Add(currNum * incCounter);
                    incCounter++;
                }
            }
            inputList.RemoveAll(x => markedToDelete.Contains(x));
            return inputList;
        }

        /// <summary>
        /// to refine further, removed all even numbers (because they are multiples of 2) except 2 and then continued like first implementation
        /// </summary>
        /// <param name="inputList"></param>
        /// <param name="maxValueInList"></param>
        /// <returns></returns>
        public static List<int> SOE_Impl3(List<int> inputList, int maxValueInList)
        {
            var sqRootOfInput = (int)Math.Sqrt(maxValueInList);

            //Remove all Even numbers except 2
            inputList.RemoveAll(x => x != 2 && x % 2 == 0);

            var markedToDelete = new List<int>();

            foreach (var currNum in inputList)
            {
                if (currNum == 2)
                    continue;
                if (currNum > sqRootOfInput)
                    break;
                if (markedToDelete.Contains(currNum))
                    continue;

                int incCounter = currNum;
                while (incCounter <= maxValueInList)
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
