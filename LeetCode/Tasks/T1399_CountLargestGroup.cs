namespace LeetCode.Tasks;

public class T1399_CountLargestGroup
{
    public int CountLargestGroup(int n)
    {
        var digitGroups = new int[37];
        for (var i = 1; i <= n; i++)
        {
            var digitsSum = 0;
            var digit = i;
            while (digit > 0)
            {
                digitsSum += digit % 10;
                digit /= 10;
            }

            digitGroups[digitsSum]++;
        }

        var maxValue = digitGroups.Max();

        return digitGroups.Count(x => x == maxValue);
    }
}