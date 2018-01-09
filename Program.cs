using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> thisAnswer = new List<int>();
            List<int> firstOne = new List<int>();
            List<int> secondOne = new List<int>();
            firstOne.Add(4);
            firstOne.Add(3);
            firstOne.Add(2);
            firstOne.Add(1);

            secondOne.Add(6);
            secondOne.Add(5);
            secondOne.Add(4);
            secondOne.Add(0);
            secondOne.Add(8);
            thisAnswer = AddTwoLists(firstOne, secondOne);

            for (int i = 0; i < thisAnswer.Count; i++)
            {
                Console.Write(thisAnswer[i] + ",");
            }

            Console.ReadKey();

        }


        /// <summary>
        /// Getting 2 lists the digits are in reversed order
        /// For 123, it is reversed to 321.
        /// For 234 + 456
        /// Lists are 432 and 654
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static List<int> AddTwoLists(List<int> first, List<int> second)
        {
            List<int> thisAnswer = new List<int>();

            int carryBit = 0;

            int shorterLengthFromTwo = Math.Min(first.Count, second.Count);
            int index = 0;

            int firstValue = 0;
            int secondValue = 0;
            int currentSum = 0;

            while (index < shorterLengthFromTwo)
            {
                firstValue = first[index];
                secondValue = second[index];
                currentSum = firstValue + secondValue + carryBit;

                //Console.Write(firstValue + ",");
                //Console.Write(secondValue+ ",");
                //Console.Write(carryBit + ",");

                thisAnswer.Add(currentSum % 10);
                carryBit = currentSum / 10;

                index++;
            }

            int whichOneIsBigger = first.Count - second.Count;

            if (whichOneIsBigger == 0 && carryBit > 0)
            {
                thisAnswer.Add(carryBit);
            }
            else if (whichOneIsBigger > 0)
            {
                while (index < shorterLengthFromTwo + whichOneIsBigger)
                {
                    firstValue = first[index];
                    //secondValue = second[index];
                    currentSum = firstValue + carryBit;

                    thisAnswer.Add(currentSum % 10);
                    carryBit = currentSum / 10;

                    index++;
                }

                if (carryBit > 0)
                {
                    thisAnswer.Add(carryBit);
                }
            }
            else //if (whichOneIsBigger < 0)
            {
                while (index < shorterLengthFromTwo + Math.Abs(whichOneIsBigger))
                {
                    //firstValue = first[index];
                    secondValue = second[index];
                    currentSum = secondValue + carryBit;

                    thisAnswer.Add(currentSum % 10);
                    carryBit = currentSum / 10;

                    index++;
                }

                if (carryBit > 0)
                {
                    thisAnswer.Add(carryBit);
                }
            }

            return thisAnswer;
        }
        
    }
}
