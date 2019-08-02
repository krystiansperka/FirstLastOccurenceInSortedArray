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
            return GetRange(testArray, x);
        }

        public int[] RunTest2()
        {
            int[] testArray = { 1, 3, 3, 5, 7, 8, 9, 9, 9, 15 };
            int x = 9;
            return GetRange(testArray, x);
        }

        public int[] RunTest3()
        {
            int[] testArray = { 100, 150, 150, 153 };
            int x = 150;
            return GetRange(testArray, x);
        }

        public int[] RunTest4()
        {
            int[] testArray = { 1, 2, 3, 4, 5, 6, 10 };
            int x = 9;
            return GetRange(testArray, x);
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
                    if (outputArrayPosition == 0)
                    {
                        outputArrayPosition++;
                    }


                }
            }

            return outputArray;
        }

    }
}
