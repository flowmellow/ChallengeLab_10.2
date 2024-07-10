/*
You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
Merge nums1 and nums2 into a single array sorted in non-decreasing order.
The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
Example 1:
Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
Output: [1,2,2,3,5,6]
Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
Example 2:
Input: nums1 = [1], m = 1, nums2 = [], n = 0
Output: [1]
Explanation: The arrays we are merging are [1] and [].
The result of the merge is [1].
Example 3:
Input: nums1 = [0], m = 0, nums2 = [1], n = 1
Output: [1]
Explanation: The arrays we are merging are [] and [1].
The result of the merge is [1].
Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
*/

using System.Globalization;

namespace ChallengeLab_10._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 4, 5, 6, 0, 0, 0 };
            int[] nums2 = {1, 2, 3 };
            int m = 3;
            int n = 3;

            Solution solution = new Solution();

            solution.merge(nums1, m, nums2, n);

            foreach (int i in nums1) 
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", nums1));
        }
    }

    public class Solution
    {
        public void merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1; // last valid element in nums1
            int j = n - 1; // last valid element in nums2
            int k = m + n - 1; // this is the last position in nums1 due to being large enough to hold all valid elements from nums1 and nums2
            while (j >= 0) // since only nums2 may have a lower amount of elements we want to use it as a reference to process all elements
                           // when j is equal to zero we will have entered the loop for the last time
                           // the input arrays are already sorted so a comparison of the larger value is all that is needed
            {
                if (i >= 0 && nums1[i] > nums2[j]) //note: this is a comparison of the last valid indexed values
                                                   // below code determines assigment based on value to back of nums[k] 
                {
                    nums1[k--] = nums1[i--]; // if condition is true nums1[i] is assinged to nums[k] then both decremented
                }
                else
                {
                    nums1[k--] = nums2[j--];// if condition is false nums2[j] is assinged to nums[k] then both decremented
                }
            }
        }
    }
}
