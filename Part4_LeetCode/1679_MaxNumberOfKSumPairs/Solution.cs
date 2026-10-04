
// Time  complexity O(NlogN) 
// Space complexity O(1) 

// This solution as we learned (two pointers) in the workshop.
public int MaxOperations_Sort(int[] nums, int k)
{

    Array.Sort(nums);

    int left = 0;
    int right = nums.Length - 1;
    int operations = 0;

    while (left < right)
    {


        if (nums[left] + nums[right] == k)
        {
            operations++;
            left++;
            right--;
        }
        else if (nums[left] + nums[right] < k)
        {
            left++;
        }
        else
        {
            right--;
        }
    }

    return operations;

}




// Time  complexity O(N) 
// Space complexity O(N)

// better answer (without sorting)
public int MaxOperations_Dictionary(int[] nums, int k)
{

    Dictionary<int, int> mynums = new Dictionary<int, int>();


    foreach (var n in nums)
    {
        if (!mynums.ContainsKey(n))
        {
            mynums[n] = 1;
        }
        else
        {
            mynums[n] += 1;
        }

    }


    int operations = 0;


    int val;
    int secondnum;

    foreach (var n in nums)
    {
        if (mynums[n] == 0)
        {
            continue;
        }

        mynums[n] -= 1;

        secondnum = k - n;

        if (mynums.TryGetValue(secondnum, out val) && val > 0)
        {
            operations++;

            mynums[secondnum] = val - 1;
        }


    }

    return operations;


}
