using System;
using System.Collections;
using System.Collections.Generic;
/*
Given a sorted array, A, with possibly duplicated elements, find the indices of the first and last occurrences of a target element, x. Return -1 if the target is not found.

Example:
Input: A = [1,3,3,5,7,8,9,9,9,15], target = 9
Output: [6,8]

Input: A = [100, 150, 150, 153], target = 150
Output: [1,2]

Input: A = [1,2,3,4,5,6,10], target = 9
Output: [-1, -1]
Here is a function signature example:

class Solution: 
  def getRange(self, arr, target):
    # Fill this in.
  
# Test program 
arr = [1, 2, 2, 2, 2, 3, 4, 7, 8, 8] 
x = 2
print(Solution().getRange(arr, x))
# [1, 4]
*/

namespace FirstLastOccurenceInSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var solution = new Solution();
            solution.RunTest1();
            solution.RunTest2();
            solution.RunTest3();
            solution.RunTest4();
        }
    }

    public class Solution
    {
        //public List<int> inputList = new List<int>();
        //public int[] outputList = new int[2];

        public int[] RunTest1()
        {
            int[] testArray = { 1, 2, 2, 2, 2, 3, 4, 7, 8, 8 };
            int x = 2;
            //return GetRange(testArray, x);
            return GetRangeBiDirectional(testArray, x);
        }

        public int[] RunTest2()
        {
            int[] testArray = { 1, 3, 3, 5, 7, 8, 9, 9, 9, 15 };
            int x = 9;
            //return GetRange(testArray, x);
            return GetRangeBiDirectional(testArray, x);
        }

        public int[] RunTest3()
        {
            int[] testArray = { 100, 150, 150, 153 };
            int x = 150;
            //return GetRange(testArray, x);
            return GetRangeBiDirectional(testArray, x);
        }

        public int[] RunTest4()
        {
            int[] testArray = { 1, 2, 3, 4, 5, 6, 10 };
            int x = 9;
            //return GetRange(testArray, x);
            return GetRangeBiDirectional(testArray, x);
        }



        public int[] GetRange(int[] sortedArray, int elementX)
        {
            int[] outputArray = { -1, -1 };
            int outputArrayPosition = 0;


            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (elementX == sortedArray[i])
                {
                    outputArray[outputArrayPosition] = i;

                    if (outputArrayPosition < (outputArray.Length - 1))
                    {
                        outputArrayPosition++;
                    }
                }

                if (elementX < sortedArray[i])
                {
                    break;
                }

            }

            return outputArray;
        }

        public int[] GetRange_PP_1(int[] sortedArray, int ElementX)
        {
            int firstOccurenceOfElementX = -1;
            int lastOccurenceOfElementX = -1;

            for (int i = 0; i < sortedArray.Length -1; i++)
                if (sortedArray[i] == ElementX) { firstOccurenceOfElementX = i; break; }

            if (firstOccurenceOfElementX > 0)
                for (int i = firstOccurenceOfElementX; i < sortedArray.Length; i++)
                    if (sortedArray[i] == ElementX) { lastOccurenceOfElementX = i; break; }

            return new[] { firstOccurenceOfElementX, lastOccurenceOfElementX };
        }


        public int[] GetRange_PP_2(int[] sortedArray, int elementX)
        {
            int[] outputArray = { -1, -1 };
            int minIndex = 0;
            int maxIndex = sortedArray.Length - 1;

            while (minIndex <= maxIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;
                if (elementX == sortedArray[midIndex])
                {
                    for (int i = midIndex; i>= 0; i--)
                    {
                        if (elementX > sortedArray[i]) break;
                        outputArray[0] = i;
                    }

                    for (int i = midIndex; i < sortedArray.Length; i++)
                    {
                        if (elementX < sortedArray[i]) break;
                        outputArray[1] = i;
                    }

                    return outputArray;

                }
                else if (elementX < sortedArray[midIndex])
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    minIndex = midIndex + 1;
                }
            }

            return outputArray;
        }

        public int[] GetRangeBiDirectional(int[] sortedArray, int elementX)
        {
            int[] outputArray = { -1, -1 };
            //int outputArrayPosition = 0;

            int lowIndex = 0;
            int highIndex = sortedArray.Length - 1;

            while (lowIndex < highIndex)
            {
                if (sortedArray[lowIndex] == elementX & outputArray[0] == -1)
                {
                    outputArray[0] = lowIndex;
                }
                else if (sortedArray[lowIndex] < elementX)
                {
                    lowIndex++;
                }

                if (sortedArray[highIndex] == elementX & outputArray[1] == -1)
                {
                    outputArray[1] = highIndex;
                }
                else if (sortedArray[highIndex] > elementX)
                {
                    highIndex--;
                }

                if (outputArray[0] != -1 & outputArray[1] != -1)
                    break; 

            }


            return outputArray;
        }
    }
}
