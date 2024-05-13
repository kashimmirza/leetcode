
using System;
using System.Collections.Generic;
using System.Linq;



public partial class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums1 = { 1, 2, 3 };
        int[] nums2 = { 4,5 };
        int m = nums1.Length;
        int n= nums2.Length;
        solution.Merge(nums1, m, nums2, n);

        string[] words = { "bella", "label", "roller" };
        CommonCharacters bb = new CommonCharacters();
        bb.CommonChars(words);

    }
}

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int i = m - 1;
        int j = n - 1;
        int combineIndex = m + n - 1;
        while (i >= 0 && j >= 0)
        {

            if (nums1[i] > nums2[j])
            {
                nums1[combineIndex] = nums2[i];
                i--;

            }
            else
            {
                nums1[combineIndex] = nums2[j];
                j--;

            }
            combineIndex--;
        }
        while (i >= 0)
        {
            nums1[combineIndex] = nums1[i];
            i--;
            combineIndex--;

        }
        while (j >= 0)
        {
            nums1[combineIndex] = nums2[j];
            j--;
            combineIndex--;

        }
    }
}