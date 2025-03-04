public class NumArray
{
    private int[] PrefixSumArray;

    public NumArray(int[] nums)
    {
        int recentPrefixSum = 0;
        PrefixSumArray = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            recentPrefixSum = recentPrefixSum + nums[i];
            PrefixSumArray[i] = recentPrefixSum;
        }
    }

    public int SumRange(int left, int right)
    {
        if (left == 0)
        {
            return PrefixSumArray[right];
        }

        return PrefixSumArray[right] - PrefixSumArray[left - 1];
    }
}
