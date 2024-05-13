// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Xml;

public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums1 = { 1, 2, 3, 4, 0, 0, 0 };
        int[] nums2 = { 2, 5, 6 };
        int[] result = solution.Intersect(nums1, nums2);
        Console.WriteLine("Intersection:");
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
        int[] nums = { 1, 2 };
        int k = 2;
        Solution1 solution2 = new Solution1();
        solution2.FindKthLargest(nums, k);
        int[] arr = { 3, 5, 5 };
        Solutionval solutionvalid = new Solutionval();
        solutionvalid.ValidMountainArray(arr);
        Solutionduplicate solutionduplicate = new Solutionduplicate();
        solutionduplicate.RemoveDuplicates(nums);
        Solutionremoveduplicate solutionremoveduplicate = new Solutionremoveduplicate();
        int[] arr1 = { 1, 0, 2, 3, 0, 4, 5, 0 };
        solutionremoveduplicate.RemoveElement(arr1, 3);
        Solutionevenfirst solutionevenfirst = new Solutionevenfirst();
        solutionevenfirst.SortArrayByParity(arr1);
        Solutiondoublezero abc = new Solutiondoublezero();
        int[] arr2 = { 1, 0, 2, 3, 0, 4, 5, 0 };
        abc.DuplicateZeros(arr2);
        int m = 4;
        int n = nums2.Length;
        SolutionMerge solutionMerge = new SolutionMerge();
        solutionMerge.Merge(nums1, m, nums2, n);
        int[] arrmax = {1,2};
        Solutionmax solutionmax= new Solutionmax();
        solutionmax.ThirdMax(arrmax);




    }
}

public class Solution1
{
    public int FindKthLargest(int[] nums, int k)
    {
        if (k < 1 || k > nums.Length)
            throw new ArgumentException("Invalid value of k");

        List<int>list = new List<int>();
        foreach (int num in nums)
        {
            list.Add(num);

        }
        return quickselect(list, k);
    }
    public int quickselect(List<int>nums, int k)
    {
        
        Random random = new Random();
        int pivotindex = random.Next(nums.Count);
        int pivot = nums[pivotindex];

        List<int>Left = new List<int>();
        List<int>Right = new List<int>();
        List<int>medium = new List<int>();
        foreach(int num in nums)
        {
            if (num > pivot)
            {
                Left.Add(num);
            }
            else if (num < pivot)
            {
                Right.Add(num);
            }
            else
            {
                medium.Add(num);
            }
        }
        if (k <= Left.Count)
        {
            return quickselect(nums, k);
        }
        else if (k > Left.Count + medium.Count)
        {
            return quickselect(nums, k-Left.Count-medium.Count);
        }
        return pivot;




    }
}


public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        int[] resultedArray = new int[1000 * 1000];
        List<int> list = new List<int>();
        
       List<int>trackindex = new List<int>();
       for(int i = 0; i < nums1.Length; i++)
        {
            for(int j = 0; j < nums2.Length; j++)
            {   
                if (nums1[i] == nums2[j])
                {
                    if (!trackindex.Contains(j))
                    {
                        trackindex.Add(j);
                        list.Add(nums2[j]);
                    }
                }
            }
        }
        resultedArray = list.ToArray();
        return resultedArray;

    }
}

public class Solutionval
{
    public bool ValidMountainArray(int[] arr)
    {
        int cnt = 0;
        if (arr.Length < 3)
        {
            return false;
        }
        int maxelement = 0;
        int maxindex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (maxelement < arr[i])
            {
                maxelement = arr[i];
                maxindex = i;
            }
        }
        for (int i = 0; i < arr.Length; i++)
        {
            if (maxelement == arr[i])
            {
                cnt++;
            }
        }
        if (maxindex == arr.Length - 1)
        {
            return false;
        }
        else if (maxindex == 0)
        {
            return false;
        }else if (cnt > 1)
        {
            return false;
        }
        
        int flag = 0;

        for (int i = 0; i < maxindex; i++)
        {
            if (arr[i] >= arr[i+1])
            {
                flag = -1;
            }
        }
        for (int i = maxindex+1; i < arr.Length-1; i++)
        {
            if (arr[i+1] >= arr[i])
            {
                flag = -1;
            }
        }


        if (flag == 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}


public class Solutionduplicate
{
    public int RemoveDuplicates(int[] nums)
    {

        if (nums.Length == 1)
        {
            return 1;
        }
        int k = findingUnique(nums);

        int len = nums.Length;
        int[] expected = new int[k];
        int index = 0;
        for (int i = 0; i < len; i++)
        {
            if (i == 0 || nums[i] != nums[i - 1])
            {
                expected[index] = nums[i];
                index++;

            }

        }

        Array.Sort(expected);
        for (int i = 0; i < expected.Length; i++)
        {
            nums[i] = expected[i];
        }
        for (int i = expected.Length; i < nums.Length; i++)
        {
            nums[i] = 0;
        }



        return k;

    }
    int findingUnique(int[] nums)
    {
        int unique = 0;

        int len = nums.Length;
        int index = 0;
        for (int i = 0; i < len; i++)
        {
            if (i == 0 || nums[i] != nums[i - 1])
            {
                unique++;

                index++;

            }

        }
        return index;


    }

}

public class Solutionremoveduplicate
{
    public int RemoveElement(int[] nums, int val)
    {
        int expectedlen = 0;
        int cnt = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                cnt++;
            }
        }
        expectedlen = nums.Length - cnt;
        Array.Sort(nums, 0, expectedlen);
        
        int[] expectedresult = new int[expectedlen];
        int index = 0;
        for (int i = 0; i <nums.Length; i++)
        {
            if (nums[i] != val)
            {
                expectedresult[index] = nums[i];
                index++;
            }
        }
        return expectedresult.Length;

    }
}
public class Solutionevenfirst
{
    public int[] SortArrayByParity(int[] nums) {
        int evenlen=0;
        int oddlen=0;
        for(int i=0;i<nums.Length;i++){
            if(nums[i]%2==0){
                evenlen++;
            }
            else{
                oddlen++;
            }
        }
        int[] evenarray = new int[evenlen];
        int[] oddarray = new int[oddlen];
        int oddindex=0;
        int evenindex=0;
        
        for(int i=0;i<nums.Length;i++){
            if(nums[i]%2==0){
                evenarray[evenindex]= nums[i];
                evenindex++;
                
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2!= 0)
            {
                oddarray[oddindex] = nums[i];
                oddindex++;

            }
        }
        int lengthCombine = evenarray.Length;
        for (int i=0;i<evenarray.Length;i++){
            nums[i]= evenarray[i];
        }
        
        for(int i=0;i<oddarray.Length;i++){
            nums[lengthCombine]= oddarray[i];
            lengthCombine++;
        }
        
        return nums;
    }
      

}

public class Solutiondoublezero
{
    public void DuplicateZeros(int[] arr)
    {
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (i != arr.Length - 1 && arr[i] == 0)
            {

                int index = i + 1;

                for (int j = arr.Length - 1; j >= i + 1; j--)
                {
                    arr[j] = arr[j - 1];
                }
                arr[index] = 0;
                i = index;
            }
        }

    }
}



public class SolutionMerge
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
                nums1[combineIndex] = nums1[i];
                i--;
                combineIndex--;

            }
            else
            {
                nums1[combineIndex] = nums2[j];
                j--;
                combineIndex--;

            }
            
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

public class Solutionmax
{
    public int ThirdMax(int[] nums)
    {
        Array.Sort(nums);
        Array.Reverse(nums);
        int thirdMaxnumber = 0;
        int cnt = 0;
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (nums[i] > nums[i + 1])
            {
                if (nums[i + 1] > nums[i + 2])
                {
                    thirdMaxnumber = nums[i + 2];
                    cnt = 1;
                    break;
                }
            }
        }
            if (cnt == 1)
            {
                return thirdMaxnumber;
            }
            return nums[nums.Length - 1];
        
    }
}



//public class Solution
//{
//    public int[] Intersect(int[] nums1, int[] nums2)
//    {
//        int[] resultedArray = new int[1000 * 1000];
//        List<int> list = new List<int>();

//       List<int>trackindex = new List<int>();
//       for(int i = 0; i < nums1.Length; i++)
//        {
//            for(int j = 0; j < nums2.Length; j++)
//            {   
//                if (nums1[i] == nums2[j])
//                {
//                    if (!trackindex.Contains(j))
//                    {
//                        trackindex.Add(j);
//                        list.Add(nums2[j]);
//                    }
//                }
//            }
//        }
//        resultedArray = list.ToArray();
//        return resultedArray;

//    }
//}

//public class Solutionval
//{
//    public bool ValidMountainArray(int[] arr)
//    {
//        int cnt = 0;
//        if (arr.Length < 3)
//        {
//            return false;
//        }
//        int maxelement = 0;
//        int maxindex = 0;
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (maxelement < arr[i])
//            {
//                maxelement = arr[i];
//                maxindex = i;
//            }
//        }
//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (maxelement == arr[i])
//            {
//                cnt++;
//            }
//        }
//        if (maxindex == arr.Length - 1)
//        {
//            return false;
//        }
//        else if (maxindex == 0)
//        {
//            return false;
//        }else if (cnt > 1)
//        {
//            return false;
//        }

//        int flag = 0;

//        for (int i = 0; i < maxindex; i++)
//        {
//            if (arr[i] >= arr[i+1])
//            {
//                flag = -1;
//            }
//        }
//        for (int i = maxindex+1; i < arr.Length-1; i++)
//        {
//            if (arr[i+1] >= arr[i])
//            {
//                flag = -1;
//            }
//        }


//        if (flag == 0)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

//    }
//}


//public class Solutionduplicate
//{
//    public int RemoveDuplicates(int[] nums)
//    {
//        int k = findingUnique(nums)+1;
//        int len = nums.Length;
//        int[] expected = new int[k];
//        int index = 0;
//        for (int i = len - 2; i >= 0; i--)
//        {
//            if (i == 0 || nums[i] != nums[i + 1])
//            {
//                expected[index] = nums[i+1];
//                index++;

//            }
//            else
//            {
//                len--;
//            }
//        }
//        expected[k-1] = nums[0];
//        Array.Sort(expected);
//        for (int i = 0; i<expected.Length; i++)
//        {
//            nums[i] = expected[i];
//        }
//        for (int i = expected.Length; i < nums.Length; i++)
//        {
//            nums[i] = 0;
//        }



//        return k;

//    }
//int findingUnique(int[] nums)
//{
//    int unique = 0;

//    int len = nums.Length;
//    int index = 0;
//    for (int i = len - 2; i >= 0; i--)
//    {
//        if (i == 0 || nums[i] != nums[i + 1])
//        {
//            unique++;

//            index++;

//        }
//        else
//        {
//            len--;
//        }
//    }
//    return index;


//}
//}

public class SolutioncombinetwoarraySorted
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int index = m;
        for (int i = 0; i < n; i++)
        {
            nums1[index] = nums2[i];
            index++;

        }
        Array.Sort(nums1);

    }
}
