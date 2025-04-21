namespace LeetCode.Tasks;

public class T2145_CountTheHiddenSequences
{
    public int NumberOfArrays(int[] differences, int lower, int upper) {
        long count = upper - lower + 1;
        var (longLower, longUpper) = ((long)lower, (long)upper);
        var (min, max) = GetBorders(differences, lower);
        if (min < longLower)
        {
            count -= (lower - min);
            longLower = min;
        }

        if (max > longUpper)
        {
            count -= (max - upper);
            longUpper = max;
        }
        
        (min, max) = GetBorders(differences, upper);
        if (min < longLower)
        {
            count -= (lower - min);
        }

        if (max > longUpper)
        {
            count -= (max - upper);
        }
        
        return Math.Max((int)count, 0);
    }

    private (long min, long max) GetBorders(int[] differences, int startValue)
    {
        long current = startValue;
        long min = current;
        long max = current;
        
        foreach (var diff in differences)
        {
            current -= diff;
            if (current < min)
                min = current;
            if (current > max)
                max = current;
        }
        
        return (min, max);
    }
}