namespace LeetCode.Tasks;

public class T2873_MaximumValueOfAnOrderedTripletI
{
    public long MaximumTripletValue(int[] nums)
    {
        long maxTriplet = 0, iMax = 0, dMax = 0;
        
        foreach (var kNum in nums)
        {
            maxTriplet = Math.Max(maxTriplet, dMax * kNum);
            dMax = Math.Max(dMax, iMax - kNum);
            iMax = Math.Max(iMax, kNum);
        }
        return maxTriplet;
    }
}